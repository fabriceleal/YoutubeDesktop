using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noesis.Javascript;
using System.ComponentModel;

namespace YoutubeDesktop.Youtube
{
    /// <summary>
    /// Base class for handling the dictionary of strings to object representation of
    /// javascript structures by the Noesis library.
    /// </summary>
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

        /// <summary>
        /// Gets the value of key in the object o, considered a dictionary. In javascript,
        /// is equivalent to calling o.key as an attribute getter.
        /// </summary>
        /// <param name="o">The object to search, used as a dictionary</param>
        /// <param name="key">The key to look up.</param>
        /// <remarks>
        /// This function returns null if the object as not been specified,
        /// or if the key is null, or if the object specified is not a dictionary 
        /// of string to object, or if the dictionary itself doesn't contains the key.
        /// Otherwise, it will return the value of the key in the dictionary.
        /// </remarks>
        /// <returns></returns>
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

        /// <summary>
        /// Calls the GetByKey(object, string) using the internal data as the object
        /// to search.
        /// </summary>
        /// <remarks>
        /// Look at the documentation of GetByKey(object, string).
        /// </remarks>
        public object GetByKey(string key)
        {
            return GetByKey(data, key);
        }

        // -----GetByIndex-----

        /// <summary>
        /// Gets the value of index in the object o, considered an array. In javascript,
        /// is equivalent to calling o[idx].
        /// </summary>
        /// <param name="o">The object to search, used as an array.</param>
        /// <param name="idx">The index to look up.</param>
        /// This function returns null if the object as not been specified,
        /// or if the idx is less than zero, or if the object specified is not an array 
        /// of objects, or if the array itself doesn't contains the index.
        /// Otherwise, it will return the value of the index in the array.
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

            return _wrk[idx];
        }

        /// <summary>
        /// Calls the GetByIndex(object, int) using the internal data as the object
        /// to search.
        /// </summary>
        /// <remarks>
        /// Look at the documentation of GetByIndex(object, int).
        /// </remarks>
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

        /// <summary>
        /// Gets a RawYoutubeType instance wrapping the result of the lookup of the 
        /// attribute with the name of the given key in the internal object.
        /// </summary>
        /// <param name="key">The key to lookup as an attribute.</param>
        /// <returns>A RawYoutubeTube instance with the data fetched.</returns>
        public RawYoutubeType this[string key]
        {
            get
            {
                if (!String.IsNullOrEmpty(root))
                    return new RawYoutubeType(GetByKey(GetByKey(data, root), key));
                return new RawYoutubeType(GetByKey(key));
            }
        }

        /// <summary>
        /// Gets a RawYoutubeType instance wrapping the result of the lookup of the 
        /// element with the given index in the internal object.
        /// </summary>
        /// <param name="idx">The index to lookup.</param>
        /// <returns>A RawYoutubeTube instance with the data fetched.</returns>
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
