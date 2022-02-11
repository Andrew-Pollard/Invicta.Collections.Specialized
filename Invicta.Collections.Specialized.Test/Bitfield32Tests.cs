using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Invicta.Collections.Specialized.Test {
	[TestClass]
	public class Bitfield32Tests {

		[TestMethod]
		public void Constructor_default() {
			Bitfield32 Bitfield32 = new();

			Assert.AreEqual(Bitfield32.Raw, 0u);
		}

		[TestMethod]
		public void Constructor_uint() {
			Bitfield32 Bitfield32 = new(123);

			Assert.AreEqual(Bitfield32.Raw, 123u);
		}

		[TestMethod]
		public void Constructor_other_Bitfield8() {
			Bitfield8 Bitfield8 = new(123);
			Bitfield32 Bitfield32 = new(Bitfield8);

			Assert.AreEqual(Bitfield32.Raw, 123u);
		}

		[TestMethod]
		public void Constructor_other_Bitfield16() {
			Bitfield16 Bitfield16 = new(123);
			Bitfield32 Bitfield32 = new(Bitfield16);

			Assert.AreEqual(Bitfield32.Raw, 123u);
		}

		[TestMethod]
		public void Constructor_other_Bitfield32() {
			Bitfield32 Bitfield32_0 = new(123);
			Bitfield32 Bitfield32_1 = new(Bitfield32_0);

			Assert.AreEqual(Bitfield32_1.Raw, 123u);
		}


		[TestMethod]
		public void Indexer_Index_set_TooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[-1] = true);
		}

		[TestMethod]
		public void Indexer_Index_set_TooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[32] = true);
		}


		[TestMethod]
		public void Indexer_Index_get_TooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[-1]);
		}

		[TestMethod]
		public void Indexer_Index_get_TooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[32]);
		}


		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[-200..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndOk() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[-100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooSmallEndTooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[-100..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[0..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartOkEndTooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[0..100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[100..-100] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndOk() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[100..1] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_StartTooBigEndTooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[100..200] = 1);
		}

		[TestMethod]
		public void Indexer_Range_set_Backwards() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[31..1] = 1);
		}


		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[-200..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndOk() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[-100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooSmallEndTooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[-100..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[0..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartOkEndTooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[0..100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooSmall() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[100..-100]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndOk() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[100..1]);
		}

		[TestMethod]
		public void Indexer_Range_get_StartTooBigEndTooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[100..200]);
		}

		[TestMethod]
		public void Indexer_Range_get_Backwards() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = Bitfield32[31..1]);
		}


		[TestMethod]
		public void Indexer_Range_set_ValueTooBig() {
			Bitfield32 Bitfield32 = new();

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Bitfield32[0..31] = 2147483648);
		}
	}
}