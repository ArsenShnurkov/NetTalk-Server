using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTalk.Common.Validation;

public class RuleViolation
{
    public string ErrorMessage { get; private set; }
    public string PropertyName { get; private set; }

    public RuleViolation(string errorMessage, string propertyName)
    {
        ErrorMessage = errorMessage;
        PropertyName = propertyName;
    }
}

public class RuleViolationCollection : List<RuleViolation>
{
    public void Add(string errorMessage, string propertyName)
    {
        this.Add(new RuleViolation(errorMessage, propertyName));
    }

    private string CurrentCheck { get; set; }
    private string CurrentName { get; set; }
    private string CurrentValue { get; set; }
    public RuleViolationCollection For(string PropertyField, string PropertyName, string Value)
    {
        CurrentCheck = PropertyField;
        CurrentName = PropertyName;
        CurrentValue = Value;
        return this;
    }

    public RuleViolationCollection MaxLength(int Length)
    {

        if (!NetTalkIsValid.HasLength(CurrentValue, Length, true))
            Add(string.Format("طول {0} نمی تواند بیش از {1} کاراکتر باشد", CurrentName, Length), CurrentCheck);
        return this;
    }

    public RuleViolationCollection MinLength(int Length)
    {

        if (!NetTalkIsValid.HasMinLength(CurrentValue, Length, true))
            Add(string.Format("حداقل طول {0} باید {1} کاراکتر باشد.", CurrentName, Length), CurrentCheck);
        return this;
    }

    public RuleViolationCollection NotNull()
    {

        if (NetTalkIsValid.IsNull(CurrentValue))
            Add(string.Format("{0} نمی تواند خالی باشد", CurrentName), CurrentCheck);
        return this;
    }

    public RuleViolationCollection MatchRegex(string Pattern)
    {

        if (!NetTalkIsValid.Match(CurrentValue, Pattern))
            Add(string.Format("{0} دارای فرمت صحیح نیست", CurrentName), CurrentCheck);
        return this;
    }

    public RuleViolationCollection BetweenLength(int MinLength, int MaxLength)
    {

        if (!NetTalkIsValid.HasMinMaxLength(CurrentValue, MinLength, MaxLength, true))
            Add(string.Format("{0} باید بین {1} تا {2} کاراکتر باشد.", CurrentName, MinLength, MaxLength), CurrentCheck);
        return this;
    }

    public RuleViolationCollection Email()
    {

        if (!NetTalkIsValid.IsEmail(CurrentValue))
            Add("فرمت ایمیل وارد شده صحیح نیست", CurrentCheck);
        return this;
    }

    public RuleViolationCollection Url()
    {

        if (!NetTalkIsValid.IsUrl(CurrentValue))
            Add("فرمت آدرس وارد شده صحیح نیست", CurrentCheck);
        return this;
    }

    public RuleViolationCollection Date()
    {

        if (!NetTalkIsValid.IsDate(CurrentValue))
            Add("فرمت تاریخ وارد شده صحیح نیست", CurrentCheck);
        return this;
    }

    public RuleViolationCollection DateTime()
    {

        if (!NetTalkIsValid.IsDatetime(CurrentValue))
            Add("فرمت تاریخ و ساعت وارد شده صحیح نیست", CurrentCheck);
        return this;
    }

    public RuleViolationCollection Time()
    {

        if (!NetTalkIsValid.IsTime(CurrentValue))
            Add("فرمت ساعت وارد شده صحیح نیست", CurrentCheck);
        return this;
    }

    public RuleViolationCollection LatinNumAndChar()
    {

        if (!NetTalkIsValid.IsLatinCharAndNum(CurrentValue))
            Add(CurrentName + " فرمت وارد شده صحیح نیست - فقط اعداد و حروف لاتین مجاز است", CurrentCheck);
        return this;
    }

    public RuleViolationCollection LatinChar()
    {
        if (!NetTalkIsValid.IsLatinChar(CurrentValue))
            Add( CurrentName + " فرمت وارد شده صحیح نیست - فقط حروف لاتین مجاز است", CurrentCheck);
        return this;
    }

    public RuleViolationCollection LengthEqual(int Len)
    {
        if (!string.IsNullOrEmpty(CurrentValue))
            if (CurrentValue.Length != Len)
                Add(string.Format(CurrentName +"طول رشته باید مساوی {0} باشد", Len), CurrentCheck);

        return this;
    }

    public RuleViolationCollection Number()
    {
        if (!NetTalkIsValid.IsNumber(CurrentValue))
            Add(CurrentName + "فقط اعداد مجاز است.", CurrentCheck);
        return this;
    }

    public RuleViolationCollection Digit()
    {
        if (!NetTalkIsValid.IsDigit(CurrentValue))
            Add(CurrentName + "فقط اعداد مجاز است.", CurrentCheck);
        return this;
    }

    public RuleViolationCollection FarsiChar()
    {
        if (!NetTalkIsValid.IsFarsiChar(CurrentValue))
            Add(CurrentName + " فقط حروف فارسی مجاز است", CurrentCheck);
        return this;
    }

    public bool IsValid
    {
        get
        {
            return (this.Count == 0);
        }
    }
}