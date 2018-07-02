namespace schedule.data.helpers
{
    using System;
    using System.Configuration;
    using System.Xml;

    internal class MyConfig : AppSettingsReader
    {
        private string _cfgFile = "";// (Application.ExecutablePath + ".Config");
        private XmlNode node;

        public string GetValue(string key) => 
            Convert.ToString(this.GetValue(key, typeof(string)));

        public new object GetValue(string key, System.Type sType)
        {
            XmlDocument doc = new XmlDocument();
            object attribute = string.Empty;
            this.loadDoc(doc);
            string xpath = key.Substring(0, key.LastIndexOf("//"));
            try
            {
                this.node = doc.SelectSingleNode(xpath);
                if (this.node != null)
                {
                    XmlElement element = (XmlElement) this.node.SelectSingleNode(key);
                    if (element != null)
                    {
                        attribute = element.GetAttribute("value");
                    }
                }
                if (sType != typeof(string))
                {
                    if (sType == typeof(bool))
                    {
                        return ((attribute.Equals("True") || attribute.Equals("False")) && Convert.ToBoolean(attribute));
                    }
                    if (sType == typeof(int))
                    {
                        return Convert.ToInt32(attribute);
                    }
                    if (sType == typeof(double))
                    {
                        return Convert.ToDouble(attribute);
                    }
                    if (sType == typeof(DateTime))
                    {
                        return Convert.ToDateTime(attribute);
                    }
                }
                return Convert.ToString(attribute);
            }
            catch
            {
                return string.Empty;
            }
        }

        private void loadDoc(XmlDocument doc)
        {
            doc.Load(this._cfgFile);
        }

        public bool removeElement(string key)
        {
            XmlDocument doc = new XmlDocument();
            this.loadDoc(doc);
            try
            {
                string xpath = key.Substring(0, key.LastIndexOf("//"));
                this.node = doc.SelectSingleNode(xpath);
                if (this.node == null)
                {
                    return false;
                }
                XmlNode oldChild = this.node.SelectSingleNode(key);
                this.node.RemoveChild(oldChild);
                this.saveDoc(doc, this._cfgFile);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        private void saveDoc(XmlDocument doc, string docPath)
        {
            if (!this._cfgFile.Equals("web.config"))
            {
                try
                {
                    XmlTextWriter w = new XmlTextWriter(docPath, null) {
                        Formatting = Formatting.Indented
                    };
                    doc.WriteTo(w);
                    w.Flush();
                    w.Close();
                }
                catch
                {
                }
            }
        }

        public bool SetValue(string key, string val)
        {
            XmlDocument doc = new XmlDocument();
            this.loadDoc(doc);
            try
            {
                string xpath = key.Substring(0, key.LastIndexOf("//"));
                this.node = doc.SelectSingleNode(xpath);
                if (this.node == null)
                {
                    return false;
                }
                XmlElement element = (XmlElement) this.node.SelectSingleNode(key);
                if (element != null)
                {
                    element.SetAttribute("value", val);
                }
                else
                {
                    xpath = key.Substring(key.LastIndexOf("//") + 2);
                    XmlElement newChild = doc.CreateElement(xpath.Substring(0, xpath.IndexOf("[@")).Trim());
                    xpath = xpath.Substring(xpath.IndexOf("'") + 1);
                    newChild.SetAttribute("key", xpath.Substring(0, xpath.IndexOf("'")));
                    newChild.SetAttribute("value", val);
                    this.node.AppendChild(newChild);
                }
                this.saveDoc(doc, this._cfgFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ConfigFile
        {
            get => 
                this._cfgFile;
            set
            {
                this._cfgFile = "";// Application.StartupPath + @"\" + value;
            }
        }
    }
}

