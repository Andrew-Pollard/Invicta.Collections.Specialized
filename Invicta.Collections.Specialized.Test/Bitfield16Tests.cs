using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Invicta.Collections.Specialized.Test {
	[TestClass]
	public class Bitfield16Tests {

		[TestMethod]
		public void Constructor_default() {
			Bitfield16 Bitfield16 = new();

			Assert.AreEqual(Bitfield16.Raw, 0);
		}

		[TestMethod]
		public void Constructor_ushort() {
			Bitfield16 Bitfield16 = new(123);

			Assert.AreEqual(Bitfield16.Raw, 123);
		}

		[TestMethod]
		public void Constructor_other_Bitfield8() {
			Bitfield8 Bitfield8 = new(123);
			Bitfield16 Bitfield16 = new(Bitfield8);

			Assert.AreEqual(Bitfield16.Raw, 123);
		}

		[TestMethod]
		public void Constructor_other_Bitfield16() {
			Bitfield16 Bitfield16_0 = new(123);
			Bitfield16 Bitfield16_1 = new(Bitfield16_0);

			Assert.AreEqual(Bitfield16_1.Raw, 123);
		}


		[TestMethod]
		public void Indexer_Index_set_TooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[-1] = true);
		}

		[TestMethod]
		public void Indexer_Index_set_TooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[16] = true);
		}


		[TestMethod]
		public void Indexer_Index_get_TooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[-1]);
		}

		[TestMethod]
		public void Indexer_Index_get_TooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[16]);
		}


		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[-200..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndOk() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[-100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[-100..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[0..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[0..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[100..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndOk() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[100..200] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_Backwards() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[15..1] = 1);
		}


		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[-200..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndOk() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[-100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[-100..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[0..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[0..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooSmall() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[100..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndOk() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[100..200]);
		}

		[TestMethod]
		public void Indexer_Range_get_Backwards() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield16[15..1]);
		}


		[TestMethod]
		public void Indexer_Range_set_ValueTooBig() {
			Bitfield16 Bitfield16 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield16[0..15] = 32768);
		}
	}
}