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
#if DEBUG
				if (Bit < 0 || 31 < Bit)
					throw new IndexOutOfRangeException();
#endif
				return ((Raw >> Bit) & 1u) == 1u;
			}

			set {
				int Bit = index.IsFromEnd ? 32 - index.Value : index.Value;
#if DEBUG
				if (Bit < 0 || 31 < Bit)
					throw new IndexOutOfRangeException();
#endif
				Raw = Raw & ~(1u << Bit) | (value ? 1u : 0u << Bit);
			}
		}


		public uint this[Range range] {
			get {
				int Start = range.Start.IsFromEnd ? 32 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 32 - range.End.Value : range.End.Value;
#if DEBUG
				if (Start < 0 || 31 < Start)
					throw new IndexOutOfRangeException();

				if (End < 0 || 32 < End)
					throw new IndexOutOfRangeException();
#endif
				uint Mask = (1u << End - Start) - 1u;
				return Raw >> Start & Mask;
			}

			set {
				int Start = range.Start.IsFromEnd ? 32 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 32 - range.End.Value : range.End.Value;
#if DEBUG
				if (Start < 0 || 31 < Start)
					throw new IndexOutOfRangeException();

				if (End < 0 || 32 < End)
					throw new IndexOutOfRangeException();
#endif
				uint Mask = (1u << End - Start) - 1u;
				Raw = Raw & ~(Mask << Start) | ((value & Mask) << Start);
			}
		}


		public override string ToString() {
			return "0b" + Convert.ToString((int) Raw, 2).PadLeft(32, '0');
		}
	}
}
