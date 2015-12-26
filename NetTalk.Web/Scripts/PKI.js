var PKIClass = function() {
    
    if (typeof(oCAPICOM) == "object") {
        if (oCAPICOM.object != null) {
            this.IsInstalled = true;
        } else {
            this.IsInstalled = false;
        };
    } else {
        this.IsInstalled = false;
    };
    if (this.IsInstalled)
        this.Load();
};

PKIClass.prototype.Load = function() {
    this.CAPICOM_STORE_OPEN_READ_ONLY = 0;
    this.CAPICOM_CURRENT_USER_STORE = 2;
    this.CAPICOM_SMART_CARD_USER_STORE = 4;
    this.CAPICOM_CERTIFICATE_FIND_SHA1_HASH = 0;
    this.CAPICOM_CERTIFICATE_FIND_SUBJECT_NAME = 1;
    this.CAPICOM_CERTIFICATE_FIND_EXTENDED_PROPERTY = 6;
    this.CAPICOM_CERTIFICATE_FIND_TIME_VALID = 9;
    this.CAPICOM_CERTIFICATE_FIND_KEY_USAGE = 12;
    this.CAPICOM_DIGITAL_SIGNATURE_KEY_USAGE = 0x00000080;
    this.CAPICOM_AUTHENTICATED_ATTRIBUTE_SIGNING_TIME = 0;
    this.CAPICOM_INFO_SUBJECT_SIMPLE_NAME = 0;
    this.CAPICOM_ENCODE_BASE64 = 0;
    this.CAPICOM_E_CANCELLED = -2138568446;
    this.CERT_KEY_SPEC_PROP_ID = 6;
    this.CAPICOM_HASH_ALGORITHM_SHA1 = 0;

    this.CAPICOM_CHECK_NONE = 0;
    this.CAPICOM_CHECK_TRUSTED_ROOT = 1;
    this.CAPICOM_CHECK_TIME_VALIDITY = 2;
    this.CAPICOM_CHECK_SIGNATURE_VALIDITY = 4;
    this.CAPICOM_CHECK_ONLINE_REVOCATION_STATUS = 8;
    this.CAPICOM_CHECK_OFFLINE_REVOCATION_STATUS = 16;

    this.CAPICOM_TRUST_IS_NOT_TIME_VALID = 1;
    this.CAPICOM_TRUST_IS_NOT_TIME_NESTED = 2;
    this.CAPICOM_TRUST_IS_REVOKED = 4;
    this.CAPICOM_TRUST_IS_NOT_SIGNATURE_VALID = 8;
    this.CAPICOM_TRUST_IS_NOT_VALID_FOR_USAGE = 16;
    this.CAPICOM_TRUST_IS_UNTRUSTED_ROOT = 32;
    this.CAPICOM_TRUST_REVOCATION_STATUS_UNKNOWN = 64;
    this.CAPICOM_TRUST_IS_CYCLIC = 128;
    this.CAPICOM_TRUST_IS_PARTIAL_CHAIN = 65536;
    this.CAPICOM_TRUST_CTL_IS_NOT_TIME_VALID = 131072;
    this.CAPICOM_TRUST_CTL_IS_NOT_SIGNATURE_VALID = 262144;
    this.CAPICOM_TRUST_CTL_IS_NOT_VALID_FOR_USAGE = 524288;
    this.CAPICOM_VERIFY_SIGNATURE_ONLY = 0;

    this.CAPICOM_ENCRYPTION_ALGORITHM_RC2 = 0;
    this.CAPICOM_ENCRYPTION_ALGORITHM_RC4 = 1;
    this.CAPICOM_ENCRYPTION_ALGORITHM_DES = 2;
    this.CAPICOM_ENCRYPTION_ALGORITHM_3DES = 3;
    this.CAPICOM_ENCRYPTION_ALGORITHM_AES = 4;
    this.CAPICOM_ENCRYPTION_KEY_LENGTH_MAXIMUM = 0;
    this.CAPICOM_ENCRYPTION_KEY_LENGTH_40_BITS = 1;
    this.CAPICOM_ENCRYPTION_KEY_LENGTH_56_BITS = 2;
    this.CAPICOM_ENCRYPTION_KEY_LENGTH_128_BITS = 3;
    this.CAPICOM_ENCRYPTION_KEY_LENGTH_192_BITS = 4;
    this.CAPICOM_ENCRYPTION_KEY_LENGTH_256_BITS = 5;
    this.CAPICOM_SECRET_PASSWORD = 0;
    this.CAPICOM_ENCODE_BASE64 = 0;
    this.CAPICOM_ENCODE_BINARY = 1;
    this.CAPICOM_ENCODE_ANY = -1;
    this.CAPICOM_VERIFY_SIGNATURE_AND_CERTIFICATE = 1;
    this.CAPICOM_CERTIFICATE_FIND_SHA1_HASH = 0;

    this.Certificate = null;

    this.req;
    this.sender;
    this.IsExpired;
};
///آیا گواهی انتخاب شده است
PKIClass.prototype.HasCertificate = function() {
    return (this.Certificate != null);
};
///متد هش اطلاعات
PKIClass.prototype.HashData = function(StringValue) {
    var HashedData = new ActiveXObject("CAPICOM.HashedData");
    HashedData.Algorithm = this.CAPICOM_HASH_ALGORITHM_SHA1;
    HashedData.Hash(StringValue);
    return HashedData.Value;
};
///آیا گواهی دیجیتال معتبر است
PKIClass.prototype.IsCertificateValid = function(oCertificate, ServerTime) {
    var Result = {
        IsValid: false,
        Message: "",
        IsExpired: false,
        Data: null
    };
    var Certificate = oCertificate;

    if (ServerTime) {
        if ((Date.parse(Certificate.ValidToDate) < Date.parse(ServerTime)) || (Date.parse(Certificate.ValidFromDate) > Date.parse(ServerTime))) {
            Result.IsExpired = true;
            Result.Data = {
                ValidTo: Date.parse(Certificate.ValidToDate),
                ValidFrom: Date.parse(Certificate.ValidFromDate)
            };
            Result.Message = "اعتبار گواهی منقضی شده است";
        };
    };

    Certificate.IsValid().CheckFlag = (this.CAPICOM_CHECK_TIME_VALIDITY | this.CAPICOM_CHECK_SIGNATURE_VALIDITY); //| CAPICOM_CHECK_ONLINE_REVOCATION_STATUS);
    if (Certificate.IsValid().Result == true) {
        Result.IsValid = true;
    } else {
        Result.IsValid = false;
        Result.Message = "گواهی شما معتبر نمی باشد - اشکال نامشخص";

        var Chain = new ActiveXObject("CAPICOM.Chain");
        Chain.Build(Certificate);

        if (this.CAPICOM_TRUST_IS_NOT_SIGNATURE_VALID & Chain.Status) {
            //SetMessage("CryptoAPI found a problem with the signature on '" + Certificate.GetInfo(this.CAPICOM_INFO_SUBJECT_SIMPLE_NAME) + "'");                        
            Result.Data = { ErrorCode: 401 };
            Result.Message = 'فرآیند امضای دیجیتال امکان پذیر نمی باشد 401';
        } else if ((this.CAPICOM_TRUST_IS_UNTRUSTED_ROOT & Chain.Status) || (this.CAPICOM_TRUST_IS_PARTIAL_CHAIN & Chain.Status)) {
            //SetMessage("CryptoAPI was unable to chain '" + Certificate.GetInfo(this.CAPICOM_INFO_SUBJECT_SIMPLE_NAME) + "' to a trusted authority");
            Result.Data = { ErrorCode: 402 };
            Result.Message = 'فرآیند امضای دیجیتال امکان پذیر نمی باشد 402';
        } else if (this.CAPICOM_TRUST_IS_CYCLIC & Chain.Status) {
            //SetMessage("CAPICOM_TRUST_IS_CYCLIC");
            Result.Data = { ErrorCode: 403 };
            Result.Message = '403 فرآیند امضای دیجیتال امکان پذیر نمی باشد';
        } else if (this.CAPICOM_TRUST_CTL_IS_NOT_TIME_VALID & Chain.Status) {
            Result.Data = { ErrorCode: 404 };
            Result.Message = "404 تاریخ اعتبار گواهی نامه دیجیتال شما به پایان رسیده است";
        } else if (this.CAPICOM_TRUST_CTL_IS_NOT_SIGNATURE_VALID & Chain.Status) {
            Result.Data = { ErrorCode: 405 };
            Result.Message = "گواهی نامه دیجیتال شما اعتبار ندارد 405";
        } else if (this.CAPICOM_TRUST_CTL_IS_NOT_VALID_FOR_USAGE & Chain.Status) {
            //SetMessage("CAPICOM_TRUST_CTL_IS_NOT_VALID_FOR_USAGE");
            Result.Data = { ErrorCode: 406 };
            Result.Message = 'فرآیند امضای دیجیتال امکان پذیر نمی باشد 406 ';
        } else if (this.CAPICOM_TRUST_IS_NOT_TIME_VALID & Chain.Status) {
            Result.Data = { ErrorCode: 2407 };
            Result.Message = "تاریخ اعتبار گواهی نامه دیجیتال شما به پایان رسیده است 2407 ";
        } else if (this.CAPICOM_TRUST_IS_NOT_TIME_NESTED & Chain.Status) {
            //SetMessage("CAPICOM_TRUST_IS_NOT_TIME_NESTED");
            Result.Data = { ErrorCode: 408 };
            Result.Message = '408 فرآیند امضای دیجیتال امکان پذیر نمی باشد';
        } else if (this.CAPICOM_TRUST_IS_NOT_VALID_FOR_USAGE & Chain.Status) {
            //SetMessage("CAPICOM_TRUST_IS_NOT_VALID_FOR_USAGE");
            Result.Data = { ErrorCode: 409 };
            Result.Message = '409 فرآیند امضای دیجیتال امکان پذیر نمی باشد';
        } else if (this.CAPICOM_TRUST_IS_REVOKED & Chain.Status) {
            //SetMessage("CryptoAPI determined that '" + Certificate.GetInfo(this.CAPICOM_INFO_SUBJECT_SIMPLE_NAME) + "' or one of its issuers was revoked.");
            Result.Data = { ErrorCode: 410 };
            Result.Message = '410 فرآیند امضای دیجیتال امکان پذیر نمی باشد';
        } else if (this.CAPICOM_TRUST_REVOCATION_STATUS_UNKNOWN & Chain.Status) {
            Result.Data = { ErrorCode: 411 };
            Result.Message = 'اعتبار گواهي ديجيتال ' + Certificate.GetInfo(this.CAPICOM_INFO_SUBJECT_SIMPLE_NAME) + 'قابل تاييد نمي باشد';
        };
    };
    return Result;
};
///انتخاب گواهی دیجیتال توسط کاربر
PKIClass.prototype.SelectCertificate = function(ServerTime) {
    try {

        this.MyStore = new ActiveXObject("CAPICOM.Store");
        this.FilteredCertificates = new ActiveXObject("CAPICOM.Certificates");

        this.MyStore.Open(2, "My", 0);

        if (this.MyStore.Certificates.Count != 0) {
            this.FilteredCertificates = this.MyStore.Certificates.Select('انتخاب گواهی دیجیتال', 'یکی از گواهیهای دیجیتال را انتخاب کنید', false);

            if (this.FilteredCertificates.Count != 0) {
                //                        this.Certificate = new ActiveXObject("CAPICOM.Certificate");
                this.Certificate = this.FilteredCertificates.Item(1);

                if (this.Certificate != null) {
                    var Result = this.IsCertificateValid(this.Certificate, ServerTime);
                    if (!Result.IsValid)
                        alert(Result.Message);
                    return Result.IsValid;
                } else {
                    alert('فرآیند امضای دیجیتال امکان پذیر نمی باشد 411');
                    return false;
                };
            } else {
                alert('گواهي ديجيتال موجود در سخت افزار متعلق به كد كاربري وارد شده نمي باشد');
                return false;
            };
        }
        else {
            alert('لطفا سخت افزار حاوي گواهي ديجيتال خود را به كامپيوتر متصل نمائيد');
            return false;
        };

    }
    catch (e) {
        if (e.number != this.CAPICOM_E_CANCELLED) {
            alert('فرآیند امضای دیجیتال امکان پذیر نمی باشد 411');
            // SetMessage("فرآیند امضای دیجیتال امکان پذیر نمی باشد 411");
            // SetMessage(e.description)
            return false;
        };
    };
};
///امضای دیجیتال
PKIClass.prototype.Sign = function(val, ServerTime) {
    var Result = {
        IsSuccess: false,
        Data: ''
    };

    try {
        
        var SignedData = new ActiveXObject("CAPICOM.SignedData");
        var Signer = new ActiveXObject("CAPICOM.Signer");
        var TimeAttribute = new ActiveXObject("CAPICOM.Attribute");
        SignedData.Content = val;
        Signer.Certificate = this.Certificate;
        
        var Today = new Date(ServerTime);

        TimeAttribute.Name = this.CAPICOM_AUTHENTICATED_ATTRIBUTE_SIGNING_TIME;
        TimeAttribute.Value = Today.getVarDate();
        Today = null;
        Signer.AuthenticatedAttributes.Add(TimeAttribute);
        szSignature = SignedData.Sign(Signer, false, this.CAPICOM_ENCODE_BASE64);

        if (this.VerifySign(val, szSignature)) {
            Result.IsSuccess = true;
            Result.Data = szSignature;
        };
    }
    catch (e) { };

    return Result;
};
///تایید امضای دیجیتال
PKIClass.prototype.VerifySign = function(Message, SignDATA) {

    var Sign = new ActiveXObject("CAPICOM.SignedData");
    // Sign.Content = Message;
    try {
        Sign.Verify(SignDATA, false, this.CAPICOM_VERIFY_SIGNATURE_ONLY);
        //SetMessage('امضا صحيح است');
    } catch (ex) {
        return false;
    };
    return true;
};
///انتخاب اتوماتیک امضای دیجیتال کاربر
PKIClass.prototype.SelectDefault = function() {
    try {
        this.MyStore = new ActiveXObject("CAPICOM.Store");
        this.FilteredCertificates = new ActiveXObject("CAPICOM.Certificates");
        this.MyStore.Open(2, "My", 0);

        if (this.MyStore.Certificates.Count != 0) {
            this.FilteredCertificates = this.MyStore.Certificates.Item(1);
            if (this.FilteredCertificates.Count != 0) {
                //                        this.Certificate = new ActiveXObject("CAPICOM.Certificate");
                this.Certificate = this.FilteredCertificates;

                if (this.Certificate != null) {
                    var Result = this.IsCertificateValid(this.Certificate, null);
                    if (!Result.IsValid)
                        alert(Result.Message);
                    return Result.IsValid;
                } else {
                    return false;
                }
            } else {
                return false;
            };
        }
        else {
            return false;
        };
    }
    catch (e) { }
};
PKIClass.prototype.FindByThumbprint = function(szThumbprint) {
    var MyStore = new ActiveXObject("CAPICOM.Store");
    var FoundCertificates = new ActiveXObject("CAPICOM.Certificates");
    try {
        MyStore.Open(CAPICOM_CURRENT_USER_STORE, "My", CAPICOM_STORE_OPEN_READ_ONLY);
    }
    catch (e) {
        return false;
    };
    return MyStore.Certificates.Find(0, szThumbprint);
};

var pki = null;
var PKISelect = function(id) {
    if (!pki) {
        pki = new PKIClass();
    };
    if (pki.SelectCertificate()) {
        var name = pki.Certificate.GetInfo(0);
        $("#" + id + "_text").val(name);
    };
};

var PKIShow = function(id) {
    if (!pki) {
        pki = new PKIClass();
    };
    if (pki.HasCertificate()) {
        pki.Certificate.Display();
    };
};

var PKISign = function(obj) {
    if (!pki) {
        pki = new PKIClass();
    };
    var id = params.id;
    var username = params.username;
    var pass = params.pass;
    var captcha = params.captcha;

    if (pki.IsInstalled) {
        pass = $("#" + pass).val();
        username = $("#" + username).val();
        captcha = $("#" + captcha).val();
        if (pass && username && captcha) {
            pass = pki.HashData(pass);
            var data = "<login><Password>" + pass + "</Password><UserName>" + username +
            "</UserName><Captcha>" + captcha + "</Captcha></login>";
            var hasdata = false;
            if (pki.HasCertificate()) {
                $.ajax({
                    url: '/Public/GetDate',
                    type: 'GET',
                    async: false,
                    cache: false,
                    success: function(data) {
                        hasdata = data;
                    }
                });
                if (hasdata) {
                    var res = pki.Sign(data, hasdata);
                    if (res.IsSuccess) {
                        var thumbprint = pki.Certificate.Thumbprint;
                        var signData = res.Data;

                        $("#" + id + "_thumbprint").val(thumbprint);
                        $("#" + id + "_sing").val(signData);

                    } else {
                        alert('فرآیند امضای دیجیتال موفقیت آمیز نبود!');
                    };
                } else {
                    alert('عدم امکان برقراری ارتباط با سرور');
                };
            };
        };
    };
};