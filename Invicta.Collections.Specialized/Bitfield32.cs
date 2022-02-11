namespace Invicta.Collections.Specialized {

	public struct Bitfield32 {
		public uint Raw { get; set; }


		public Bitfield32(uint data) {
			Raw = data;
		}

		public Bitfield32(Bitfield8 other) {
			Raw = other.Raw;
		}

		public Bitfield32(Bitfield16 other) {
			Raw = other.Raw;
		}

		public Bitfield32(Bitfield32 other) {
			Raw = other.Raw;
		}


		public bool this[Index index] {
			get {
				int Bit = index.IsFromEnd ? 32 - index.Value : index.Value;

				if (Bit < 0 || 31 < Bit)
					throw new ArgumentOutOfRangeException(nameof(index), $"Must be in the interval [0, 31]");

				return ((Raw >> Bit) & 1u) == 1u;
			}

			set {
				int Bit = index.IsFromEnd ? 32 - index.Value : index.Value;

				if (Bit < 0 || 31 < Bit)
					throw new ArgumentOutOfRangeException(nameof(index), $"Must be in the interval [0, 31]");

				Raw = Raw & ~(1u << Bit) | (value ? 1u : 0u << Bit);
			}
		}


		public uint this[Range range] {
			get {
				int Start = range.Start.IsFromEnd ? 32 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 32 - range.End.Value : range.End.Value;

				if (Start < 0 || 31 < Start)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be in the interval [0, 31]");

				if (End < 1 || 32 < End)
					throw new ArgumentOutOfRangeException(nameof(range), $"End must be in the interval [1, 32]");

				if (Start >= End)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be greater than end");

				uint Mask = (1u << End - Start) - 1u;
				return Raw >> Start & Mask;
			}

			set {
				int Start = range.Start.IsFromEnd ? 32 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 32 - range.End.Value : range.End.Value;

				if (Start < 0 || 31 < Start)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be in the interval [0, 31]");

				if (End < 1 || 32 < End)
					throw new ArgumentOutOfRangeException(nameof(range), $"End must be in the interval [1, 32]");

				if (Start >= End)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be greater than end");

				if (Math.Floor(Math.Log2(value)) + 1 > End - Start)
					throw new ArgumentOutOfRangeException(nameof(value), $"Value too big to fit into {End - Start} bits");

				uint Mask = (1u << End - Start) - 1u;
				Raw = Raw & ~(Mask << Start) | ((value & Mask) << Start);
			}
		}


		public override string ToString() {
			return "0b" + Convert.ToString((int) Raw, 2).PadLeft(32, '0');
		}
	}
}
