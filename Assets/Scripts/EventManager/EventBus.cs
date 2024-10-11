using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CustomEventBus
{
    /// <summary>
    /// The EventBus class implements a simple event system for managing subscriptions and broadcasting events.
    /// </summary>
    public class EventBus : IService
    {
        // Dictionary to hold callbacks associated with event types, organized by priority.
        private Dictionary<string, List<CallbackWithPriority>> _signalCallbacks = new Dictionary<string, List<CallbackWithPriority>>();

        /// <summary>
        /// Subscribes a callback to a specific event type.
        /// Callbacks can be prioritized; higher priority callbacks are invoked first.
        /// </summary>
        /// <typeparam name="T">The type of the event.</typeparam>
        /// <param name="callback">The callback method to invoke when the event is triggered.</param>
        /// <param name="priority">The priority of the callback (default is 0).</param>
        public void Subscribe<T>(Action<T> callback, int priority = 0)
        {
            string key = typeof(T).Name;

            // Add the callback to the dictionary, ensuring it is ordered by priority.
            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Add(new CallbackWithPriority(priority, callback));
            }
            else
            {
                _signalCallbacks.Add(key, new List<CallbackWithPriority>() { new(priority, callback) });
            }

            // Sort callbacks by priority in descending order.
            _signalCallbacks[key] = _signalCallbacks[key].OrderByDescending(x => x.Priority).ToList();
        }

        /// <summary>
        /// Invokes all callbacks associated with a specific event type, passing the event signal to each callback.
        /// </summary>
        /// <typeparam name="T">The type of the event.</typeparam>
        /// <param name="signal">The event signal to pass to the callbacks.</param>
        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;

            // Invoke all callbacks for the specified event type.
            if (_signalCallbacks.ContainsKey(key))
            {
                foreach (var obj in _signalCallbacks[key])
                {
                    var callback = obj.Callback as Action<T>;
                    callback?.Invoke(signal);
                }
            }
        }

        /// <summary>
        /// Unsubscribes a callback from a specific event type.
        /// </summary>
        /// <typeparam name="T">The type of the event.</typeparam>
        /// <param name="callback">The callback method to remove from the subscription list.</param>
        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;

            // Remove the callback from the dictionary if it exists.
            if (_signalCallbacks.ContainsKey(key))
            {
                var callbackToDelete = _signalCallbacks[key].FirstOrDefault(x => x.Callback.Equals(callback));
                if (callbackToDelete != null)
                {
                    _signalCallbacks[key].Remove(callbackToDelete);
                }
            }
            else
            {
                Debug.LogErrorFormat("Trying to unsubscribe from a non-existing key! {0}", key);
            }
        }
    }
}
