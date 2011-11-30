using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noesis.Javascript;
using System.ComponentModel;

namespace YoutubeDesktop.Youtube
{
    public class RawYoutubeType
    {
        public string RootKey { get { return root; } protected set { root = value; } }

        public object Data { get { return data; } protected set { data = value; } }

        // -----GetAsArray-----
        public static object[] GetAsArray(object o, string key)
        {
            return GetByKey(o, key) as object[];
        }

        public object[] GetAsArray(string key)
        {
            return GetAsArray(data, key);
        }

        public object[] GetAsArray()
        {
            return data as object[];
        }

        // -----GetAsHash-----

        public static Dictionary<string, object> GetAsHash(object o, string key)
        {
            return GetByKey(o, key) as Dictionary<string, object>;
        }

        public Dictionary<string, object> GetAsHash(string key)
        {
            return GetAsHash(data, key);
        }

        public Dictionary<string, object> GetAsHash()
        {
            return data as Dictionary<string, object>;
        }

        // -----GetAsScalar-----
        public static object GetAsScalar(object o, string key)
        {
            return GetByKey(GetByKey(o, key), "$t");
        }

        public object GetAsScalar(string key)
        {
            return GetByKey(GetByKey(data, key), "$t");
        }

        public object GetAsScalar()
        {
            return GetByKey(data, "$t");
        }

        // -----GetByKey-----
        public static object GetByKey(object o, string key)
        {
            if (o == null)
                return null;

            if (String.IsNullOrEmpty(key))
                return null;

            Dictionary<string, object> _wrk = o as Dictionary<string, object>;
            if (_wrk == null)
                return null;

            if (!_wrk.ContainsKey(key))
                return null;

            return _wrk[key];
        }

        public object GetByKey(string key)
        {
            return GetByKey(data, key);
        }

        // -----GetByIndex-----
        public static object GetByIndex(object o, int idx)
        {
            if (o == null)
                return null;

            if (idx < 0)
                return null;

            object[] _wrk = o as object[];
            if (_wrk == null)
                return null;

            if (_wrk.Length <= idx)
                return null;

            return (_wrk)[idx];
        }

        public object GetByIndex(int idx)
        {
            return GetByIndex(data, idx);
        }


        private string root;
        private object data;

        protected RawYoutubeType(object rawData)
        {
            data = rawData;
        }

        protected RawYoutubeType(string rootElem, object rawData)
            : this(rawData)
        {
            root = rootElem;
        }


        public RawYoutubeType this[string key]
        {
            get
            {
                if (!String.IsNullOrEmpty(root))
                    return new RawYoutubeType(GetByKey(GetByKey(data, root), key));
                return new RawYoutubeType(GetByKey(key));
            }
        }

        public RawYoutubeType this[int idx]
        {
            get
            {
                if (!String.IsNullOrEmpty(root))
                    return new RawYoutubeType(GetByIndex(GetByKey(data, root), idx));
                return new RawYoutubeType(GetByIndex(idx));
            }
        }

    }
}
