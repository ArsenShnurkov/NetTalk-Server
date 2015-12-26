using System.Web.UI;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Reflection;
using System;

namespace NetTalk.Common.UserControls
{
    public class NetTalkUserControl : UserControl
    {
        #region Fields
        // Collection of custom objects that will be
        // used in the Render method of the control
        // to replace variables with actual values.
        private List<object> _ReplaceObjects = new List<object>();
        /// <summary>
        /// Collection of key values that will be
        // used in the Render method of the control
        // to replace variables with actual values.
        /// </summary>
        private NameValueCollection _ReplaceStrings = new NameValueCollection();
        #endregion

        #region Properties
        /// <summary>
        /// Replace object collection.
        /// </summary>
        public List<object> ReplaceObjects
        {
            get { return _ReplaceObjects; }
            set { _ReplaceObjects = value; }
        }
        /// <summary>
        /// Replace string collection.
        /// </summary>
        public NameValueCollection ReplaceStrings
        {
            get { return _ReplaceStrings; }
            set { _ReplaceStrings = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Advanced version of find control.
        /// </summary>
        /// <typeparam name="T">Type of control to find.</typeparam>
        /// <param name="id">Control id to find.</param>
        /// <returns>Control of given type.</returns>
        /// <remarks>
        /// If the control with the given id is not found
        /// a new control instance of the given type is returned.
        /// </remarks>
        public T FindControl<T>(string id) where T : Control
        {
            // User normal FindControl method to get the control
            Control _control = this.FindControl(id);

            // If control was found and is of the correct type we return it
            if (_control != null && _control is T)
            {
                return (T)_control;
            }

            // Use reflection to create a new instance of the control
            return (T)Activator.CreateInstance(typeof(T));
        }

        /// <summary>
        /// Replace our custom objects with actual values.
        /// </summary>
        protected override void Render(HtmlTextWriter writer)
        {
            // Check if any replace objects have been added
            if (ReplaceObjects.Count > 0 || _ReplaceStrings.Count > 0)
            {
                // We are going to make a custom control render
                // and replace custom object properties with
                // actual values
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    using (HtmlTextWriter tw = new HtmlTextWriter(sw))
                    {
                        // Render HTML to stringbuilder
                        base.Render(tw);

                        // String.Replace method should perform faster than
                        // using StringBuilder.Replace.
                        string html = sb.ToString();

                        // Loop all replace object
                        for (int i = 0; i < ReplaceObjects.Count; i++)
                        {
                            // Loop trough all object's properties
                            foreach (PropertyInfo prop in ReplaceObjects[i].GetType().GetProperties())
                            {
                                if (ReplaceObjects[i] != null)
                                {
                                    object val = prop.GetValue(ReplaceObjects[i], null);
                                    if (val == null)
                                    {
                                        html = html.Replace("[" + prop.Name + "]", "");
                                    }
                                    else
                                    {
                                        html = html.Replace("[" + prop.Name + "]", val.ToString());
                                    }
                                }
                            }
                        }

                        // Loop all replace strings
                        if (_ReplaceStrings.Count > 0)
                        {
                            for (int i = 0; i < _ReplaceStrings.Count; i++)
                            {
                                html = html.Replace("[" + _ReplaceStrings.Keys[i] + "]", _ReplaceStrings[i]);
                            }
                        }

                        // Write replaced HTML to output stream
                        writer.Write(html);
                    }
                }
            }
            else
            {
                // Normal rendering
                base.Render(writer);
            }
        }
        #endregion
    }
}
