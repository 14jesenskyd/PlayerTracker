using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Server.Events;

namespace PlayerTracker.Server.Listeners {
	public interface DataTransmissionListener {
		void dataSent(DataTransmissionEvent evt);

		void dataReceived(DataTransmissionEvent evt);
	}
}
