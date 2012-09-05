using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Promotion.Common
{
    /// <summary>
    /// XML 转换
    /// </summary>
    public static class XMLConvert
    {
        /// <summary>
        /// Xml转换成对象
        /// </summary>
        /// <param name="xml">XML String</param>
        /// <param name="typeString">对象类型</param>
        /// <returns>对象</returns>
        public static object XmlToObject(string xml, Type type)
        {
            if ((xml == null) || xml == "") return null;

            XmlSerializer serializer = new XmlSerializer(type);
            StringReader reader = new StringReader(xml);
            object obj = serializer.Deserialize(reader);
            return obj;
        }

        /// <summary>
        /// 对象转换成Xml
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>XML String</returns>
        public static string ObjectToXml(object obj)
        {
            try
            {
                if (obj == null) return "";

                Type type = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(type);
                StringBuilder sb = new StringBuilder();
                StringWriter writer = new StringWriter(sb);
                serializer.Serialize(writer, obj);
                string serializedValue = sb.ToString();
                return serializedValue;
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// 对象转换成Xml
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>XML String</returns>
        public static string ObjectToXml(object obj, Type type)
        {
            try
            {
                if (obj == null) return "";

                // Type type = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(type);
                StringBuilder sb = new StringBuilder();
                StringWriter writer = new StringWriter(sb);
                serializer.Serialize(writer, obj);
                string serializedValue = sb.ToString();
                return serializedValue;
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + ex.StackTrace;
            }
        }


        /// <summary>
        /// 对象转换成Xml后存在文件!
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="obj">对象</param>
        public static void ObjectToXmlFile(string fileName, object obj)
        {
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
            writer.Write(XMLConvert.ObjectToXml(obj));
            writer.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object XmlFileToObject(string fileName, Type type)
        {
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                return XMLConvert.XmlToObject(reader.ReadToEnd(), type);
            }
        }
    }
}
