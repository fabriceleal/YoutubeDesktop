using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace YoutubeDesktop
{
    /// <summary>
    /// Class to manage asynchronous filling of controls. One can only update
    /// a control's property in code executed inside the control's thread, so
    /// the function for getting a value is executed asynchronously, but the 
    /// callback, responsible for using the value to change control's state, 
    /// is executed in the control's thread.
    /// </summary>
    /// <typeparam name="T">The return value of the function used to get the 
    /// desired value, at that will be passed to the callback.</typeparam>
    public class Assync<T>
    {
        private Action<T> _callback;
        private Control _container;
        private Func<T> _function;
        private Action<Exception> _onException;

        /// <summary>
        /// Create and execute an Assync instance. In case of any exception, a messagebox will be prompted.
        /// </summary>
        /// <typeparam name="O">The return value of the function used to get the 
        /// desired value, at that will be passed to the callback.</typeparam>
        /// <param name="container">The control that will be used to supply the UI thread to 
        /// execute callback.</param>
        /// <param name="function">Function for getting a value desired, executed async.</param>
        /// <param name="callback">Callback that will receive the value returned by function, 
        /// executed in container's thread (waits if it's handle is not created yet). </param>
        public static void Execute<O>(Control container,
                Func<O> function,
                Action<O> callback)
        {
            Assync<O> a = new Assync<O>(container, function, callback);
            a.Execute();
        }

        /// <summary>
        /// Create and execute an Assync instance, 
        /// with an action for handling any exception that might occur.
        /// </summary>
        /// <typeparam name="O">The return value of the function used to get the 
        /// desired value, at that will be passed to the callback.</typeparam>
        /// <param name="container">The control that will be used to supply the UI thread to 
        /// execute callback.</param>
        /// <param name="function">Function for getting a value desired, executed async.</param>
        /// <param name="callback">Callback that will receive the value returned by function, 
        /// executed in container's thread (waits if it's handle is not created yet). </param>
        /// <param name="onException">Callback that receives any exception that occured during 
        /// the execution of function and callback.</param>
        public static void Execute<O>(Control container,
                Func<O> function,
                Action<O> callback,
                Action<Exception> onException)
        {
            Assync<O> a = new Assync<O>(container, function, callback, onException);
            a.Execute();
        }

        /// <summary>
        /// Creates a new instance of Assync. In case of any exception, a messagebox will be prompted.
        /// </summary>
        /// <param name="container">The control that will be used to supply the UI thread to 
        /// execute callback.</param>
        /// <param name="function">Function for getting a value desired, executed async.</param>
        /// <param name="callback">Callback that will receive the value returned by function, 
        /// executed in container's thread (waits if it's handle is not created yet). </param>
        public Assync(
                Control container,
                Func<T> function,
                Action<T> callback)
            : this(container, function, callback, delegate(Exception e) { MessageBox.Show(e.Message, e.GetType().FullName); }) { }

        /// <summary>
        /// Creates a new instance of Assync, 
        /// with an action for handling any exception that might occur.
        /// </summary>
        /// <param name="container">The control that will be used to supply the UI thread to 
        /// execute callback.</param>
        /// <param name="function">Function for getting a value desired, executed async.</param>
        /// <param name="callback">Callback that will receive the value returned by function, 
        /// executed in container's thread (waits if it's handle is not created yet). </param>
        /// <param name="onException">Callback that receives any exception that occured during 
        /// the execution of function and callback.</param>
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

        /// <summary>
        /// Executes the function asynchronously. The result will be supplied to
        /// another function that is executed in the container's thread.
        /// </summary>
        public void Execute()
        {
            _function.BeginInvoke(new AsyncCallback(Callback), null);
        }

        /// <summary>
        /// Callback for the function.
        /// </summary>
        /// <param name="ar"></param>
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
