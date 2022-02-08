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
#if DEBUG
				if (Bit < 0 || 7 < Bit)
					throw new IndexOutOfRangeException();
#endif
				return (((uint) Raw >> Bit) & 1u) == 1u;
			}

			set {
				int Bit = index.IsFromEnd ? 8 - index.Value : index.Value;
#if DEBUG
				if (Bit < 0 || 7 < Bit)
					throw new IndexOutOfRangeException();
#endif
				Raw = (byte) (Raw & ~(1u << Bit) | (value ? 1u : 0u << Bit));
			}
		}


		public byte this[Range range] {
			get {
				int Start = range.Start.IsFromEnd ? 8 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 8 - range.End.Value : range.End.Value;
#if DEBUG
				if (Start < 0 || 7 < Start)
					throw new IndexOutOfRangeException();

				if (End < 0 || 8 < End)
					throw new IndexOutOfRangeException();
#endif
				uint Mask = (1u << End - Start) - 1u;
				return (byte) ((uint) Raw >> Start & Mask);
			}

			set {
				int Start = range.Start.IsFromEnd ? 8 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 8 - range.End.Value : range.End.Value;
#if DEBUG
				if (Start < 0 || 7 < Start)
					throw new IndexOutOfRangeException();

				if (End < 0 || 8 < End)
					throw new IndexOutOfRangeException();
#endif
				uint Mask = (1u << End - Start) - 1u;
				Raw = (byte) (Raw & ~(Mask << Start) | ((value & Mask) << Start));
			}
		}


		public override string ToString() {
			return "0b" + Convert.ToString(Raw, 2).PadLeft(8, '0');
		}
	}
}
