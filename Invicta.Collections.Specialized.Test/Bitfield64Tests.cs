using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Invicta.Collections.Specialized.Test {
	[TestClass]
	public class Bitfield64Tests {

		[TestMethod]
		public void Constructor_default() {
			Bitfield64 Bitfield64 = new();

			Assert.AreEqual(Bitfield64.Raw, 0ul);
		}

		[TestMethod]
		public void Constructor_uint() {
			Bitfield64 Bitfield64 = new(123);

			Assert.AreEqual(Bitfield64.Raw, 123ul);
		}

		[TestMethod]
		public void Constructor_other_Bitfield8() {
			Bitfield8 Bitfield8 = new(123);
			Bitfield64 Bitfield64 = new(Bitfield8);

			Assert.AreEqual(Bitfield64.Raw, 123ul);
		}

		[TestMethod]
		public void Constructor_other_Bitfield16() {
			Bitfield16 Bitfield16 = new(123);
			Bitfield64 Bitfield64 = new(Bitfield16);

			Assert.AreEqual(Bitfield64.Raw, 123ul);
		}

		[TestMethod]
		public void Constructor_other_Bitfield32() {
			Bitfield32 Bitfield32 = new(123);
			Bitfield64 Bitfield64 = new(Bitfield32);

			Assert.AreEqual(Bitfield64.Raw, 123ul);
		}

		[TestMethod]
		public void Constructor_other_Bitfield64() {
			Bitfield64 Bitfield64_0 = new(123);
			Bitfield64 Bitfield64_1 = new(Bitfield64_0);

			Assert.AreEqual(Bitfield64_1.Raw, 123ul);
		}


		[TestMethod]
		public void Indexer_Index_set_TooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[-1] = true);
		}

		[TestMethod]
		public void Indexer_Index_set_TooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[64] = true);
		}


		[TestMethod]
		public void Indexer_Index_get_TooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[-1]);
		}

		[TestMethod]
		public void Indexer_Index_get_TooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[64]);
		}


		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[-200..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndOk() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[-100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[-100..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[0..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[0..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[100..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndOk() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[100..200] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_Backwards() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[63..1] = 1);
		}


		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[-200..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndOk() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[-100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[-100..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[0..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[0..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooSmall() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[100..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndOk() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[100..200]);
		}

		[TestMethod]
		public void Indexer_Range_get_Backwards() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield64[63..1]);
		}


		[TestMethod]
		public void Indexer_Range_set_ValueTooBig() {
			Bitfield64 Bitfield64 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield64[0..63] = 9223372036854775808);
		}
	}
}