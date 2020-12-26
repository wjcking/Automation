using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Mapping;
using NHibernate.Mapping.Attributes;
using NHibernate.Tool.hbm2ddl;

namespace Sinowyde.DOP.DataSchema.Console
{
    public class NHSchemaUtil
    {
        public static void SchemaOutput(Assembly[] assemblies, string outputFileName, string auxiliaryFileName)
        {
            Configuration cfg = new Configuration();
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    string tableName = null;
                    {
                        object[] attributes = type.GetCustomAttributes(typeof(ClassAttribute), true);
                        if (attributes.Length == 0)
                        {
                            continue;
                        }
                        tableName = ((ClassAttribute)attributes[0]).Table;
                        if (tableName == null)
                        {
                            tableName = type.Name;
                        }
                    }

                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        object[] attributes = property.GetCustomAttributes(true);
                        foreach (Attribute attribute in attributes)
                        {
                            //唯一索引命名
                            if (attribute is NHibernate.Mapping.Attributes.PropertyAttribute)
                            {
                                //mysql数据库 uniquekey不起作用
                                if (!string.IsNullOrEmpty((attribute as NHibernate.Mapping.Attributes.PropertyAttribute).UniqueKey))
                                {
                                }
                            }
                            //外键命名
                            if (attribute is ManyToOneAttribute)
                            {
                                ManyToOneAttribute manyToOne = attribute as ManyToOneAttribute;
                                string fk = string.Format("FK_{0}_{1}", tableName, manyToOne.Column);
                                if (manyToOne.ForeignKey != fk)
                                {
                                    System.Console.WriteLine("警告: 表{0}字段{1}外键格式不正确, 应该为: {2}", tableName, manyToOne.Column, fk);
                                }
                            }
                        }
                    }
                }
                ConfigureByAttribute(cfg, assembly);
            }
            //cfg.AddAuxiliaryDatabaseObject(new SimpleAuxiliaryDatabaseObject(File.ReadAllText(auxiliaryFileName), string.Empty));
            OutputSchema(cfg, outputFileName);
        }

        public static Configuration ConfigureByAttribute(Configuration cfg, Assembly assembly)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                HbmSerializer.Default.Validate = true;
                HbmSerializer.Default.Serialize(stream, assembly);
                stream.Position = 0;
                cfg.AddInputStream(stream);
                return cfg;
            }
        }

        public static Configuration ConfigureByAttribute(Configuration cfg, Assembly assembly, string[] namespaces)
        {
            ConfigureByAttribute(cfg, assembly);
            for (int i = 0; i < cfg.ClassMappings.Count; i++)
            {
                PersistentClass pc = cfg.ClassMappings.ElementAt(i);
                if (!namespaces.Contains(cfg.ClassMappings.ElementAt(i).MappedClass.Namespace))
                {
                    cfg.ClassMappings.Remove(pc);
                }
            }
            return cfg;
        }

        public static Configuration ConfigureByAttribute(Configuration cfg, string assemblyName)
        {
            return ConfigureByAttribute(cfg, Assembly.Load(assemblyName));
        }

        public static void OutputSchema(Configuration cfg, string schemaFileName)
        {
            new SchemaExport(cfg).SetOutputFile(schemaFileName).SetDelimiter(";").Execute(false, false, false);
        }
    }
}
