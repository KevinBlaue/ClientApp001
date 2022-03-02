using System;
using System.Collections.Generic;
using System.Threading;

namespace De.HsFlensburg.ClientApp001.Service.MessageBusWithParameter
{
    public class Messenger
    {
        private static Messenger instance;
        private static readonly object lockObject = new object();

        private readonly Dictionary<Type, List<ActionIdentifier>> references =
            new Dictionary<Type, List<ActionIdentifier>>();

        private Messenger()
        {
        }

        public static Messenger Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new Messenger();
                    return instance;
                }
            }
        }

        public void Register<TNotification>(object recipient, Action<TNotification> action)
        {
            Register(recipient, null, action);
        }

        public void Register<TNotification>(object recipient, string identCode, Action<TNotification> action)
        {
            var messageType = typeof(TNotification);
            if (!references.ContainsKey(messageType))
                references.Add(messageType, new List<ActionIdentifier>());
            var actionIdent = new ActionIdentifier();
            actionIdent.Action = new WeakReferenceAction<TNotification>(recipient, action);
            actionIdent.IdentificationCode = identCode;
            references[messageType].Add(actionIdent);
        }

        public void Send<TNotification>(TNotification notification)
        {
            var type = typeof(TNotification);
            var typeActionIdentifiers = references[type];
            foreach (var ai in typeActionIdentifiers)
            {
                var actionParameter = ai.Action as IActionParameter;
                if (actionParameter != null)
                    actionParameter.ExecuteWithParameter(notification);
                else
                    ai.Action.Execute();
            }
        }

        public void Send<TNotification>(TNotification notification, string identCode)
        {
            var type = typeof(TNotification);
            var typeActionIdentifiers = references[type];
            foreach (var ai in typeActionIdentifiers)
                if (ai.IdentificationCode == identCode)
                {
                    var actionParameter = ai.Action as IActionParameter;
                    if (actionParameter != null)
                        actionParameter.ExecuteWithParameter(notification);
                    else
                        ai.Action.Execute();
                }
        }

        public void Unregister<TNotification>(object recipient)
        {
            var lockTaken = false;
            try
            {
                Monitor.Enter(references, ref lockTaken);
                foreach (var targetType in references.Keys)
                foreach (var wra in references[targetType])
                    if (wra.Action != null && wra.Action.Target == recipient)
                        wra.Action.Unload();
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(references);
            }
        }
    }
}