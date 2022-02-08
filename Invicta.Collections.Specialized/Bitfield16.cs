namespace Invicta.Collections.Specialized {

	public struct Bitfield16 {
		public ushort Raw { get; set; }


		public Bitfield16(ushort data) {
			Raw = data;
		}

		public Bitfield16(Bitfield8 other) {
			Raw = other.Raw;
		}

		public Bitfield16(Bitfield16 other) {
			Raw = other.Raw;
		}


		public bool this[Index index] {
			get {
				int Bit = index.IsFromEnd ? 16 - index.Value : index.Value;
#if DEBUG
				if (Bit < 0 || 15 < Bit)
					throw new IndexOutOfRangeException();
#endif
				return (((uint) Raw >> Bit) & 1u) == 1u;
			}

			set {
				int Bit = index.IsFromEnd ? 16 - index.Value : index.Value;
#if DEBUG
				if (Bit < 0 || 15 < Bit)
					throw new IndexOutOfRangeException();
#endif
				Raw = (ushort) (Raw & ~(1u << Bit) | (value ? 1u : 0u << Bit));
			}
		}


		public ushort this[Range range] {
			get {
				int Start = range.Start.IsFromEnd ? 16 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 16 - range.End.Value : range.End.Value;
#if DEBUG
				if (Start < 0 || 15 < Start)
					throw new IndexOutOfRangeException();

				if (End < 0 || 16 < End)
					throw new IndexOutOfRangeException();
#endif
				uint Mask = (1u << End - Start) - 1u;
				return (ushort) ((uint) Raw >> Start & Mask);
			}

			set {
				int Start = range.Start.IsFromEnd ? 16 - range.Start.Value : range.Start.Value;
				int End = range.End.IsFromEnd ? 16 - range.End.Value : range.End.Value;
#if DEBUG
				if (Start < 0 || 15 < Start)
					throw new IndexOutOfRangeException();

				if (End < 0 || 16 < End)
					throw new IndexOutOfRangeException();
#endif
				uint Mask = (1u << End - Start) - 1u;
				Raw = (ushort) (Raw & ~(Mask << Start) | ((value & Mask) << Start));
			}
		}


		public override string ToString() {
			return "0b" + Convert.ToString((short) Raw, 2).PadLeft(16, '0');
		}
	}
}
