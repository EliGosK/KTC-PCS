using System;
using System.Collections;

namespace EVOFramework.Database
{
    [Serializable]
    public sealed class ParameterCollection : CollectionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><c>value</c> is null.</exception>
        public Parameter this[int index]
        {
            get
            {
                return (Parameter)this.List[index];
            }
            set {
                if (value == null)
                    throw new ArgumentNullException();

                (value).Collection = this;
                this.List[index] = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"><c></c> is out of range.</exception>
        /// <exception cref="ArgumentNullException"><c>value</c> is null.</exception>
        public Parameter this[string ParameterName]
        {
            get
            {
                for (int i = 0; i < this.List.Count; i++)
                {
                    Parameter param = (Parameter)List[i];
                    if (param.Name == ParameterName)
                        return param;
                }
                return null;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                for (int i = 0; i < this.List.Count; i++)
                {
                    Parameter param = (Parameter)List[i];
                    if (param.Name == ParameterName)
                    {
                        ((Parameter)value).Collection = this;
                        List[i] = value;
                        return;
                    }
                }
                throw new ArgumentOutOfRangeException("Not found parameter name : " + ParameterName);
            }
        }

        public int Add(Parameter parameter)
        {
            parameter.Collection = this;
            return List.Add(parameter);
        }        

        public Parameter Add(string ParameterName, DataType dataType, object Value)
        {
            Parameter param = new Parameter(ParameterName, dataType, Value);
            param.Collection = this;
            List.Add(param);
            return param;
        }

        public Parameter Add(string ParameterName, object Value)
        {
            return Add(ParameterName, DataType.Default, Value);
        }

        public Parameter Add(string ParameterName, DataType dataType, int iSize , object Value)
        {
            Parameter param = new Parameter(ParameterName, dataType, iSize, Value);
            param.Collection = this;
            List.Add(param);
            return param;
        }
        public int IndexOf(Parameter parameter)
        {
            return List.IndexOf(parameter);
        }
        public void Insert(int index, Parameter parameter)
        {
            parameter.Collection = this;
            List.Insert(index, parameter);
        }
        public Parameter Insert(int index, string parameterName, DataType dataType, object value)
        {
            Parameter param = new Parameter(parameterName, dataType, value);
            param.Collection = this;
            List.Insert(index, param);
            return param;
        }
        public void Remove(Parameter parameter)
        {
            List.Remove(parameter);
        }
        public void Remove(string parameterName)
        {
            for (int i = 0; i < List.Count; i++)
            {
                Parameter param = (Parameter)List[i];
                if (param.Name == parameterName)
                {
                    List.RemoveAt(i);
                    break;
                }
            }
        }
        public bool Contains(Parameter parameter)
        {
            return List.Contains(parameter);
        }
        public bool Contains(string parameterName)
        {
            for (int i = 0; i < List.Count; i++)
            {
                Parameter param = (Parameter)List[i];
                if (param.Name == parameterName)
                {
                    return true;                    
                }
            }
            return false;
        }

        
    }
}
