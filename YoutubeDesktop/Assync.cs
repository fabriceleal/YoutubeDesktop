using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace YoutubeDesktop
{
    public class Assync<T>
    {
        private Action<T> _callback;
        private Control _container;
        private Func<T> _function;
        private Action<Exception> _onException;

        public static void Execute<O>(Control container,
                Func<O> function,
                Action<O> callback)
        {
            Assync<O> a = new Assync<O>(container, function, callback);
            a.Execute();
        }

        public static void Execute<O>(Control container,
                Func<O> function,
                Action<O> callback,
                Action<Exception> onException)
        {
            Assync<O> a = new Assync<O>(container, function, callback, onException);
            a.Execute();
        }

        public Assync(
                Control container,
                Func<T> function,
                Action<T> callback)
            : this(container, function, callback, delegate(Exception e) { MessageBox.Show(e.Message, e.GetType().FullName); }) { }

        public Assync(
                Control container,
                Func<T> function,
                Action<T> callback,
                Action<Exception> onException
            )
        {
            _callback = callback;
            _container = container;
            _function = function;
            _onException = onException;
        }

        public void Execute()
        {
            _function.BeginInvoke(new AsyncCallback(Callback), null);
        }

        private void Callback(IAsyncResult ar)
        {
            AsyncResult res = (AsyncResult)ar;

            T returnValue = default(T);
            try
            {
                // Gets return value ...
                returnValue = ((Func<T>)res.AsyncDelegate).EndInvoke(ar);


                // Waits here ... :)
                while (!_container.IsHandleCreated) { };

                // Starts callback in control's thread
                _container.BeginInvoke(_callback, new object[] { returnValue });
            }
            catch (Exception e)
            {
                _onException(e);
            }            
        }

    }
}
