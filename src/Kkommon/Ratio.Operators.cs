namespace Kkommon
{
    // documentation omitted for obvious implementations
    public readonly partial struct Ratio
    {
        // equality
        public static bool operator ==(Ratio left, Ratio right) => left.Equals(right);
        public static bool operator !=(Ratio left, Ratio right) => !left.Equals(right);

        // ratio arithmetic
        public static Ratio operator +(Ratio @this) => new(
            +@this.Numerator,
            +@this.Denominator
        );

        public static Ratio operator -(Ratio @this) => new(
            -@this.Numerator,
            @this.Denominator
        );

        public static Ratio operator +(Ratio left, Ratio right) => new(
            left.Denominator * right.Numerator + left.Numerator * right.Denominator,
            left.Denominator * right.Denominator
        );

        public static Ratio operator -(Ratio left, Ratio right) => new(
            left.Numerator * right.Denominator - left.Denominator * right.Numerator,
            left.Denominator * right.Denominator
        );

        public static Ratio operator *(Ratio left, Ratio right) => new(
            left.Numerator * right.Numerator,
            left.Denominator * right.Denominator
        );

        public static Ratio operator /(Ratio left, Ratio right) => new(
            left.Numerator * right.Denominator,
            left.Denominator * right.Numerator
        );

        // integer arithmetic
        public static Ratio operator +(Ratio left, int right) => new(
            left.Numerator + left.Denominator * right,
            left.Denominator
        );

        public static Ratio operator +(int left, Ratio right) => right + left;

        public static Ratio operator -(Ratio left, int right) => new(
            left.Numerator - left.Denominator * right,
            left.Denominator
        );

        public static Ratio operator -(int left, Ratio right) => new(
            right.Denominator * left - right.Numerator,
            right.Denominator
        );

        public static Ratio operator *(Ratio left, int right) => new(
            left.Numerator * right,
            left.Denominator
        );

        public static Ratio operator *(int left, Ratio right) => right * left;

        public static Ratio operator /(Ratio left, int right) => new(
            left.Numerator,
            left.Denominator * right
        );

        public static Ratio operator /(int left, Ratio right) => new(
            left * right.Denominator,
            right.Numerator
        );

        // conversions
        public static implicit operator decimal(Ratio @this) => @this.Value;
        public static implicit operator float(Ratio @this) => @this.FValue;
        public static implicit operator double(Ratio @this) => @this.DValue;
    }
}