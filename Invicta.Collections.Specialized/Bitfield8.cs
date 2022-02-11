namespace Invicta.Collections.Specialized {

	public struct Bitfield8 {
		public byte Raw { get; set; }


		public Bitfield8(byte data) {
			Raw = data;
		}

		public Bitfield8(Bitfield8 other) {
			Raw = other.Raw;
		}


		public bool this[Index index] {
			get {
				int Bit = index.IsFromEnd ? 8 - index.Value : index.Value;

				if (Bit < 0 || 7 < Bit)
					throw new ArgumentOutOfRangeException(nameof(index), $"Must be in the interval [0, 7]");

				return (((uint) Raw >> Bit) & 1u) == 1u;
			}

			set {
				int Bit = index.IsFromEnd ? 8 - index.Value : index.Value;

				if (Bit < 0 || 7 < Bit)
					throw new ArgumentOutOfRangeException(nameof(index), $"Must be in the interval [0, 7]");

				Raw = (byte) (Raw & ~(1u << Bit) | (value ? 1u : 0u << Bit));
			}
		}


		public byte this[Range range] {
			get {
				int Start = range.Start.IsFromEnd ? 8 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 8 - range.End.Value : range.End.Value;

				if (Start < 0 || 7 < Start)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be in the interval [0, 7]");

				if (End < 1 || 8 < End)
					throw new ArgumentOutOfRangeException(nameof(range), $"End must be in the interval [1, 8]");

				if (Start >= End)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be greater than end");

				uint Mask = (1u << End - Start) - 1u;
				return (byte) ((uint) Raw >> Start & Mask);
			}

			set {
				int Start = range.Start.IsFromEnd ? 8 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 8 - range.End.Value : range.End.Value;

				if (Start < 0 || 7 < Start)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be in the interval [0, 7]");

				if (End < 1 || 8 < End)
					throw new ArgumentOutOfRangeException(nameof(range), $"End must be in the interval [1, 8]");

				if (Start >= End)
					throw new ArgumentOutOfRangeException(nameof(range), $"Start must be greater than end");

				if (Math.Floor(Math.Log2(value)) + 1 > End - Start)
					throw new ArgumentOutOfRangeException(nameof(value), $"Value too big to fit into {End - Start} bits");

				uint Mask = (1u << End - Start) - 1u;
				Raw = (byte) (Raw & ~(Mask << Start) | ((value & Mask) << Start));
			}
		}


		public override string ToString() {
			return "0b" + Convert.ToString(Raw, 2).PadLeft(8, '0');
		}
	}
}
