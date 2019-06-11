using Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace WebApi.Classes
{
    public class EsConsultStarter
    {
        public ConsultResultDto LoadAndStartConsult(StartEsArgs args)
        {
            // запуск консультации
            ExpertSystem es = LoadES(args.FileName);
            es.Goal = es.Vars[args.Goal];
            Fact resFact = es.GoConsult(new VariableFromData(args.VarValues));

            // объяснение
            var workedRules = es.WorkedRules.Where(r => r.Worked == RuleWork.Signifi).ToList();
            ConsultResultDto result = new ConsultResultDto(resFact, workedRules);

            return result;
        }


        private ExpertSystem LoadES(string fileName)
        {
            try
            {
                // TODO: общий код с Forms - сделать отдельный loader

                // TODO: кэш

                string findedFileName = EsFilesHelper.FindFullName(fileName);
                if (string.IsNullOrEmpty(findedFileName))
                    throw new FileNotFoundException("Файл экспертной системы не найден");

                ExpertSystem result = null;
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = File.OpenRead(findedFileName))
                {
                    result = (ExpertSystem)bf.Deserialize(fs);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при загрузке файла ЭС", ex);
            }
        }


    }


    public class VariableFromData : IЗапросПеременной
    {
        private List<VariableValue> varValues = new List<VariableValue>();

        public VariableFromData(List<VariableValue> varValues)
        {
            this.varValues = varValues;
        }

        public Fact Запросить(Variable v, ExpertSystem es)
        {
            var data = varValues.FirstOrDefault(x => string.Equals(x.Variable, v.Name, StringComparison.InvariantCultureIgnoreCase));
            Fact result = null;
            if (data == null)
            {
                throw new Exception($"Не удалось определить значение запрашиваемой переменной {v.Name}");
            }
            else
            {
                string domainValue = v.Domain.ListVal.FirstOrDefault(x => string.Equals(x, data.Value, StringComparison.InvariantCultureIgnoreCase));

                if (string.IsNullOrEmpty(domainValue))
                    throw new Exception($"Значение переменной {v.Name} равное {data.Value} не принадлежит домену");

                result = new Fact(v, domainValue, Rightly.Yes);
            }

            return result;
        }
    }


}