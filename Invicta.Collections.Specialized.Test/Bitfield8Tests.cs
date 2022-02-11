using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Invicta.Collections.Specialized.Test {
	[TestClass]
	public class Bitfield8Tests {

		[TestMethod]
		public void Constructor_default() {
			Bitfield8 Bitfield8 = new();

			Assert.AreEqual(Bitfield8.Raw, 0);
		}

		[TestMethod]
		public void Constructor_byte() {
			Bitfield8 Bitfield8 = new(123);

			Assert.AreEqual(Bitfield8.Raw, 123);
		}

		[TestMethod]
		public void Constructor_other() {
			Bitfield8 Bitfield8_0 = new(123);
			Bitfield8 Bitfield8_1 = new(Bitfield8_0);

			Assert.AreEqual(Bitfield8_1.Raw, 123);
		}


		[TestMethod]
		public void Indexer_Index_set_TooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[-1] = true);
		}

		[TestMethod]
		public void Indexer_Index_set_TooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[8] = true);
		}


		[TestMethod]
		public void Indexer_Index_get_TooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[-1]);
		}

		[TestMethod]
		public void Indexer_Index_get_TooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[8]);
		}


		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[-200..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndOk() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[-100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[-100..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[0..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[0..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[100..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndOk() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[100..200] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_Backwards() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[7..1] = 1);
		}


		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[-200..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndOk() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[-100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[-100..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[0..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[0..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooSmall() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[100..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndOk() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[100..200]);
		}

		[TestMethod]
		public void Indexer_Range_get_Backwards() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield8[7..1]);
		}


		[TestMethod]
		public void Indexer_Range_set_ValueTooBig() {
			Bitfield8 Bitfield8 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield8[0..7] = 128);
		}
	}
}