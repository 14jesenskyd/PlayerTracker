using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Util {
	public sealed class TimeUtils {
		/**
		 * Gets the time at the instant of invocation. Includes date.
		 *
		 * @param timeFormat The format for the time to be
		 *                   in, i.e. {@code "dd MM yyyy hh:mm:ss"}
		 * @return The time string at the time of invocation,
		 * formatted per the {@code timeFormat}.
		 */
		public static String getTime() {
			//return new SimpleDateFormat(timeFormat).format(Calendar.getInstance().getTime());
			return DateTime.Now.ToShortDateString();
		}
	}
}
