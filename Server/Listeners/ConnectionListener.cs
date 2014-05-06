using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Server.Events;

namespace PlayerTracker.Server.Listeners {
	public interface ConnectionListener {
		void onConnectEvent(ConnectionEvent evt);
	}
}