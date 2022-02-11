namespace Invicta.Collections.Specialized {

	public struct Bitfield64 {
		public ulong Raw { get; set; }


		public Bitfield64(ulong data) {
			Raw = data;
		}

		public Bitfield64(Bitfield8 other) {
			Raw = other.Raw;
		}

		public Bitfield64(Bitfield16 other) {
			Raw = other.Raw;
		}

		public Bitfield64(Bitfield32 other) {
			Raw = other.Raw;
		}

		public Bitfield64(Bitfield64 other) {
			Raw = other.Raw;
		}


		public bool this[Index index] {
			get {
				int Bit = index.IsFromEnd ? 64 - index.Value : index.Value;

				if (Bit < 0 || 63 < Bit)
					throw new ArgumentOutOfRangeException(nameof(index), $"Must be in the interval [0, 63]");

				return ((Raw >> Bit) & 1ul) == 1ul;
			}

			set {
				int Bit = index.IsFromEnd ? 64 - index.Value : index.Value;

				if (Bit < 0 || 63 < Bit)
					throw new ArgumentOutOfRangeException(nameof(index), $"Must be in the interval [0, 63]");

				Raw = Raw & ~(1ul << Bit) | (value ? 1ul : 0ul << Bit);
			}
		}


		public ulong this[Range range] {
			get {
				int Start = range.Start.IsFromEnd ? 64 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 64 - range.End.Value : range.End.Value;

				if (Start < 0 || 63 < Start)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be in the interval [0, 63]");

				if (End < 1 || 64 < End)
					throw new ArgumentOutOfRangeException(nameof(range), $"End must be in the interval [1, 64]");

				if (Start >= End)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be greater than end");

				ulong Mask = (1ul << End - Start) - 1ul;
				return Raw >> Start & Mask;
			}

			set {
				int Start = range.Start.IsFromEnd ? 32 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 32 - range.End.Value : range.End.Value;

				if (Start < 0 || 63 < Start)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be in the interval [0, 63]");

				if (End < 1 || 64 < End)
					throw new ArgumentOutOfRangeException(nameof(range), $"End must be in the interval [1, 64]");

				if (Start >= End)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be greater than end");

				if (Math.Floor(Math.Log2(value)) + 1 > End - Start)
					throw new ArgumentOutOfRangeException(nameof(value), $"Value too big to fit into {End - Start} bits");

				ulong Mask = (1ul << End - Start) - 1ul;
				Raw = Raw & ~(Mask << Start) | ((value & Mask) << Start);
			}
		}


		public override string ToString() {
			return "0b" + Convert.ToString((long) Raw, 2).PadLeft(64, '0');
		}
	}
}
