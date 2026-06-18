using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace HelpdeskApp.Services
{
    public class TicketPresenceService
    {
        // Key: TicketId, Value: Set of usernames
        private readonly ConcurrentDictionary<string, HashSet<string>> _activeViewers = new();

        public event Action<string>? OnTicketPresenceChanged;
        public event Action? OnNewTicketCreated;

        public void NotifyNewTicket()
        {
            OnNewTicketCreated?.Invoke();
        }

        public void JoinTicket(string ticketId, string userName)
        {
            if (string.IsNullOrWhiteSpace(ticketId) || string.IsNullOrWhiteSpace(userName)) return;

            var viewers = _activeViewers.GetOrAdd(ticketId, _ => new HashSet<string>());
            
            lock (viewers)
            {
                if (viewers.Add(userName))
                {
                    OnTicketPresenceChanged?.Invoke(ticketId);
                }
            }
        }

        public void LeaveTicket(string ticketId, string userName)
        {
            if (string.IsNullOrWhiteSpace(ticketId) || string.IsNullOrWhiteSpace(userName)) return;

            if (_activeViewers.TryGetValue(ticketId, out var viewers))
            {
                lock (viewers)
                {
                    if (viewers.Remove(userName))
                    {
                        OnTicketPresenceChanged?.Invoke(ticketId);
                        
                        // Clean up if empty
                        if (viewers.Count == 0)
                        {
                            _activeViewers.TryRemove(ticketId, out _);
                        }
                    }
                }
            }
        }

        public IEnumerable<string> GetViewers(string ticketId)
        {
            if (string.IsNullOrWhiteSpace(ticketId)) return Enumerable.Empty<string>();

            if (_activeViewers.TryGetValue(ticketId, out var viewers))
            {
                lock (viewers)
                {
                    return viewers.ToList();
                }
            }
            return Enumerable.Empty<string>();
        }
    }
}
