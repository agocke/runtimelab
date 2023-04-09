// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using BindingFlags = System.Reflection.BindingFlags;

internal class Program
{
    private static int Main()
    {
#if !MULTIMODULE_BUILD
        TestLdstr.Run();
        TestException.Run();
        TestThreadStaticNotInitialized.Run();
        TestUntouchedThreadStaticInitialized.Run();
        TestPointers.Run();
        TestConstants.Run();
        TestArray.Run();
        TestArrayOutOfRange.Run();
        TestMdArray.Run();
        TestSimpleObject.Run();
        TestFinalizableObject.Run();
        TestStoreIntoOtherStatic.Run();
        TestCctorCycle.Run();
        TestReferenceTypeAllocation.Run();
        TestReferenceTypeWithGCPointerAllocation.Run();
        TestReferenceTypeWithReadonlyNullGCPointerAllocation.Run();
        TestRelationalOperators.Run();
        TestTryFinally.Run();
        TestTryCatch.Run();
        TestBadClass.Run();
        TestRefs.Run();
        TestDelegate.Run();
        TestInitFromOtherClass.Run();
        TestInitFromOtherClassDouble.Run();
        TestDelegateToOtherClass.Run();
        TestLotsOfBackwardsBranches.Run();
        TestDrawCircle.Run();
        TestValueTypeDup.Run();
        TestFunctionPointers.Run();
        TestGCInteraction.Run();
        TestDuplicatedFields.Run();
        TestInstanceDelegate.Run();
        TestStringFields.Run();
        TestSharedCode.Run();
#else
        Console.WriteLine("Preinitialization is disabled in multimodule builds for now. Skipping test.");
#endif

        return 100;
    }
}

class TestLdstr
{
    static string s_mine;
    static bool s_literalsEqual;

    static string GetOtherString() => "Hello";

    static TestLdstr()
    {
        s_mine = nameof(TestLdstr);
        s_literalsEqual = Object.ReferenceEquals("Hello", GetOtherString());
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestLdstr));
        Assert.AreSame(nameof(TestLdstr), s_mine);
        Assert.True(s_literalsEqual);
    }
}

class TestException
{
    static bool s_wasThrown;

    static TestException()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception)
        {
            s_wasThrown = true;
        }
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestException));
        Assert.True(s_wasThrown);
    }
}

class TestThreadStaticNotInitialized
{
    [ThreadStatic]
    static bool s_wasRun = true;

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestThreadStaticNotInitialized));
        Assert.True(s_wasRun);
    }
}

class TestUntouchedThreadStaticInitialized
{
    [ThreadStatic]
#pragma warning disable 169
    static bool s_unused;
#pragma warning restore 169
    static bool s_wasRun = true;

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestUntouchedThreadStaticInitialized));
        Assert.True(s_wasRun);
    }
}

unsafe class TestPointers
{
    static byte* s_myByte = (byte*)123;
    static void* s_myVoid = GimmeVoid(s_myByte);
    static byte*[] s_byteStarArray = new byte*[] { (byte*)123, (byte*)456 };

    static void* GimmeVoid(byte* template)
    {
        return template;
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestPointers));
        Assert.AreEqual((void*)123, s_myByte);
        Assert.AreEqual((void*)123, s_myVoid);

        Assert.AreEqual(2, s_byteStarArray.Length);
        Assert.AreEqual((byte*)123, s_byteStarArray[0]);
        Assert.AreEqual((byte*)456, s_byteStarArray[1]);
    }
}

class TestConstants
{
    static bool s_bool = true;
    static int s_smallInt = 3;
    static int s_mediumInd = 70;
    static int s_bigInt = 2000000;
    static long s_hugeInt = 20000000000;
    static float s_float = 3.14f;
    static double s_double = 3.14;

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestConstants));
        Assert.AreEqual(true, s_bool);
        Assert.AreEqual(3, s_smallInt);
        Assert.AreEqual(70, s_mediumInd);
        Assert.AreEqual(2000000, s_bigInt);
        Assert.AreEqual(20000000000, s_hugeInt);
        Assert.AreEqual(3.14f, s_float);
        Assert.AreEqual(3.14, s_double);
    }
}

class TestArray
{
    struct MyValueType
    {
        public bool B;
        public int I;
    }

    enum MyEnum
    {
        One, Two
    }

    static byte[] s_byteArray;
    static MyValueType[] s_valueTypeArray;
    static int s_byteArrayCount;
    static MyEnum[] s_enumArray;
    static byte s_byteArrayFirstElement;

    static TestArray()
    {
        s_byteArray = new byte[]
        {
            1, 2, 3, 9, 8, 7, 1, 2, 3, 9, 8, 7
        };

        s_byteArrayCount = s_byteArray.Length;

        s_valueTypeArray = new MyValueType[2]
        {
            new MyValueType { B = false, I = 555 },
            new MyValueType { B = true, I = 565 },
        };

        s_enumArray = new MyEnum[2] { MyEnum.One, MyEnum.Two };

        s_byteArrayFirstElement = s_byteArray[0];
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestArray));
        Assert.AreEqual(s_byteArray.Length, 12);
        Assert.AreEqual(s_byteArray[0], 1);
        Assert.AreEqual(s_byteArray[1], 2);
        Assert.AreEqual(s_byteArray[11], 7);
        Assert.AreEqual(s_byteArrayCount, 12);

        Assert.AreEqual(s_valueTypeArray.Length, 2);
        Assert.AreEqual(s_valueTypeArray[0].B, false);
        Assert.AreEqual(s_valueTypeArray[0].I, 555);
        Assert.AreEqual(s_valueTypeArray[1].B, true);
        Assert.AreEqual(s_valueTypeArray[1].I, 565);

        Assert.AreEqual(s_enumArray.Length, 2);
        Assert.AreEqual((int)s_enumArray[0], (int)MyEnum.One);
        Assert.AreEqual((int)s_enumArray[1], (int)MyEnum.Two);

        Assert.AreEqual(s_byteArrayFirstElement, 1);
    }
}

class TestArrayOutOfRange
{
    class OutOfRange
    {
        public static byte[] s_byteArray;

        static OutOfRange()
        {
            s_byteArray = new byte[2];
            s_byteArray[2] = 1;
        }
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(OutOfRange));

        bool thrown = false;
        try
        {
            OutOfRange.s_byteArray[0] = 1;
        }
        catch (TypeInitializationException)
        {
            thrown = true;
        }

        Assert.True(thrown);
    }
}

class TestMdArray
{
    static byte[,] s_myMdArray = new byte[10, 10];

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestMdArray));
        Assert.AreEqual(100, s_myMdArray.Length);
    }
}

class TestSimpleObject
{
    static object s_object = new object();

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestSimpleObject));
        Assert.AreSame(typeof(object), s_object.GetType());
    }
}

class TestFinalizableObject
{
    class Finalizable
    {
        ~Finalizable()
        {
            Console.WriteLine("Finalized");
        }
    }

    static object s_object = new Finalizable();

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestFinalizableObject));
        Assert.AreSame(typeof(Finalizable), s_object.GetType());
    }
}

static class TestStoreIntoOtherStatic
{
    class Park
    {
        public static int s_parked;
    }

    static TestStoreIntoOtherStatic()
    {
        Park.s_parked = 123;
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestStoreIntoOtherStatic));
    }
}

static class TestCctorCycle
{
    static readonly int s_value = Cycler.s_theValue;

    class Cycler
    {
        public static readonly int s_theValue = s_value;
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestCctorCycle));
        Assert.AreEqual(0, s_value);
    }
}

class TestReferenceTypeAllocation
{
    class ReferenceType
    {
        public int IntValue;
        public double DoubleValue;

        public ReferenceType(int intValue, double doubleValue)
        {
            IntValue = intValue;
            DoubleValue = doubleValue;
        }
    }

    static ReferenceType s_referenceType = new ReferenceType(12345, 3.14159);

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestReferenceTypeAllocation));
        Assert.AreEqual(12345, s_referenceType.IntValue);
        Assert.AreEqual(3.14159, s_referenceType.DoubleValue);
    }
}

class TestReferenceTypeWithGCPointerAllocation
{
    class ReferenceType
    {
        public string StringValue;

        public ReferenceType(string stringvalue)
        {
            StringValue = stringvalue;
        }
    }

    static ReferenceType s_referenceType = new ReferenceType("hi");

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestReferenceTypeWithGCPointerAllocation));
        Assert.AreSame("hi", s_referenceType.StringValue);
    }
}

class TestReferenceTypeWithReadonlyNullGCPointerAllocation
{
    class ReferenceType
    {
        public readonly string StringValue;

        public ReferenceType(string stringvalue)
        {
            StringValue = stringvalue;
        }
    }

    static ReferenceType s_referenceType = new ReferenceType(null);

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestReferenceTypeWithReadonlyNullGCPointerAllocation));
        Assert.AreSame(null, s_referenceType.StringValue);
    }
}

static class TestRelationalOperators
{
    static int s_zeroInt = 0;
    static double s_zeroDouble = 0.0;
    static long s_zeroLong = 0;
    static int s_minusOneInt = -1;
    static long s_minusOneLong = -1;

    static bool s_finished;

    static TestRelationalOperators()
    {
        if (s_zeroInt > 0)
            throw new Exception();
        if (s_zeroInt < 0)
            throw new Exception();
        if (s_zeroInt >= 0 && s_zeroInt <= 0)
        {
            if (s_zeroLong > 0)
                throw new Exception();
            if (s_zeroLong < 0)
                throw new Exception();
            if (s_zeroLong >= 0 && s_zeroLong <= 0)
            {
                if (s_zeroDouble > 0)
                    throw new Exception();
                if (s_zeroDouble < 0)
                    throw new Exception();
                if (s_zeroDouble >= 0 && s_zeroDouble <= 0)
                {
                    if ((uint)s_minusOneInt < (uint)s_zeroInt)
                        throw new Exception();
                    if ((uint)s_zeroInt > (uint)s_minusOneInt)
                        throw new Exception();
                    if ((ulong)s_minusOneLong < (ulong)s_zeroLong)
                        throw new Exception();
                    if ((ulong)s_zeroLong > (ulong)s_minusOneLong)
                        throw new Exception();

                    if (s_zeroInt == 0 && s_zeroLong == 0)
                        s_finished = true;
                }
            }
        }
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestRelationalOperators));
        Assert.AreEqual(true, s_finished);
    }
}

class TestTryFinally
{
    static int s_cookie;

    static TestTryFinally()
    {
        try
        {
            if (new byte[0].Length > 0)
                throw new Exception();
        }
        finally
        {
            s_cookie = 1985;
        }
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestTryFinally));
        Assert.AreEqual(1985, s_cookie);
    }
}

class TestTryCatch
{
    static int s_cookie;

    static TestTryCatch()
    {
        try
        {
            if (s_cookie > 0)
                throw null;
        }
        catch (Exception)
        {
            s_cookie = 100;
        }
        s_cookie = 2020;
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestTryCatch));
        Assert.AreEqual(2020, s_cookie);
    }
}

class TestBadClass
{
    [StructLayout(LayoutKind.Explicit)]
    class BadLayoutClass<T>
    {
    }

    static int s_cookie;
    static object s_badClass;

    static object MakeBadLayoutClass() => new BadLayoutClass<int>();

    static TestBadClass()
    {
        try
        {
            s_badClass = MakeBadLayoutClass();
            s_cookie = -1;
        }
        catch (Exception)
        {
            s_cookie = 1;
        }
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TestBadClass));
        Assert.AreEqual(1, s_cookie);
        Assert.AreSame(null, s_badClass);
    }
}

class TestRefs
{
    struct IntStruct { public int Value { get; set; } }
    struct DoubleStruct { public double Value { get; set; } }

    static IntStruct s_value1;
    static IntStruct s_value2;
    static DoubleStruct s_doubleValue;

    static ref IntStruct PickOne(int which)
    {
        if (which == 1)
            return ref s_value1;
        return ref s_value2;
    }

    static void Set(ref IntStruct location, int value)
    {
        location.Value = value;
    }

    static TestRefs()
    {
        ref IntStruct loc1 = ref PickOne(1);
        Set(ref loc1, 41);
        s_value1.Value++;

        s_value2.Value = 98;
        ref IntStruct loc2 = ref PickOne(2);
        if (loc2.Value == 98)
        {
            loc2.Value++;
        }
        if (s_value2.Value == 99)
        {
            s_value2.Value++;
        }

        ref DoubleStruct dblRef = ref s_doubleValue;
        dblRef.Value = 3.14;
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestRefs));
        Assert.AreEqual(42, s_value1.Value);
        Assert.AreEqual(100, s_value2.Value);
        Assert.AreEqual(3.14, s_doubleValue.Value);
    }
}

class TestDelegate
{
    static Func<int> s_delegate = GetVal;

    static int GetVal() => 42;

    static Func<int> s_lambda = () => 2020;

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestDelegate));
        Assert.AreEqual(42, s_delegate());
        Assert.AreEqual(2020, s_lambda());
    }
}

class TestInitFromOtherClass
{
    class OtherClass
    {
        public static readonly int IntValue = 456;
        public static readonly string StringValue = "Hello";
        public static readonly object ObjectValue = new object();
    }

    static int s_intValue = OtherClass.IntValue;
    static string s_stringValue = OtherClass.StringValue;
    static object s_objectValue = OtherClass.ObjectValue;

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestInitFromOtherClass));
        Assert.AreEqual(OtherClass.IntValue, s_intValue);
        Assert.AreSame(OtherClass.StringValue, s_stringValue);
        Assert.AreSame(OtherClass.ObjectValue, s_objectValue);
    }
}

class TestInitFromOtherClassDouble
{
    class OtherClass
    {
        public static readonly int IntValue = 456;
        public static readonly string StringValue = "Hello";
        public static readonly object ObjectValue = new object();
    }

    class OtherClassDouble
    {
        public static readonly int IntValue = OtherClass.IntValue;
        public static readonly string StringValue = OtherClass.StringValue;
        public static readonly object ObjectValue = OtherClass.ObjectValue;
    }

    static int s_intValue = OtherClassDouble.IntValue;
    static string s_stringValue = OtherClassDouble.StringValue;
    static object s_objectValue = OtherClassDouble.ObjectValue;

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestInitFromOtherClassDouble));
        Assert.AreEqual(OtherClass.IntValue, s_intValue);
        Assert.AreSame(OtherClass.StringValue, s_stringValue);
        Assert.AreSame(OtherClass.ObjectValue, s_objectValue);
    }
}


class TestDelegateToOtherClass
{
    static Func<int> s_getCookie = OtherClass.s_otherclass.GetCookie;
    static Func<Type> s_getStringType = OtherClass.s_otherString.GetType;
    static Func<int> s_getCookieDoubleIndirect = OtherClass.s_getCookie;
    static Func<Type> s_getStringTypeDoubleIndirect = OtherClass.s_getStringType;
    static Func<int> s_getCookieIndirected = OtherClass.s_otherclassFromYetAnother.GetCookie;
    static Func<Type> s_getStringTypeIndirected = OtherClass.s_otherStringFromYetAnother.GetType;

    class OtherClass
    {
        int _cookie;
        public static readonly OtherClass s_otherclass = new OtherClass(4040);
        public static readonly string s_otherString = "1";
        public static readonly Func<int> s_getCookie = YetAnotherClass.s_otherclass.GetCookie;
        public static readonly Func<Type> s_getStringType = YetAnotherClass.s_otherString.GetType;
        public static readonly OtherClass s_otherclassFromYetAnother = YetAnotherClass.s_otherclass;
        public static readonly string s_otherStringFromYetAnother = YetAnotherClass.s_otherString;
        public OtherClass(int cookie) { _cookie = cookie; }
        public int GetCookie() => _cookie;
    }

    class YetAnotherClass
    {
        public static readonly OtherClass s_otherclass = new OtherClass(1010);
        public static readonly string s_otherString = "1";
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(TestDelegateToOtherClass));

        Assert.AreEqual(4040, s_getCookie());
        Assert.AreSame(OtherClass.s_otherclass, s_getCookie.Target);
        Assert.AreSame(typeof(string), s_getStringType());
        Assert.AreSame(OtherClass.s_otherString, s_getStringType.Target);

        Assert.AreEqual(1010, s_getCookieDoubleIndirect());
        Assert.AreSame(YetAnotherClass.s_otherclass, s_getCookieDoubleIndirect.Target);
        Assert.AreSame(typeof(string), s_getStringTypeDoubleIndirect());
        Assert.AreSame(YetAnotherClass.s_otherString, s_getStringTypeDoubleIndirect.Target);
        Assert.AreSame(OtherClass.s_getCookie, s_getCookieDoubleIndirect);
        Assert.AreSame(OtherClass.s_getStringType, s_getStringTypeDoubleIndirect);

        Assert.AreEqual(1010, s_getCookieIndirected());
        Assert.AreSame(YetAnotherClass.s_otherclass, s_getCookieIndirected.Target);
        Assert.AreSame(typeof(string), s_getStringTypeIndirected());
        Assert.AreSame(YetAnotherClass.s_otherString, s_getStringTypeIndirected.Target);
    }
}

class TestLotsOfBackwardsBranches
{
    class TypeWithLotsOfBackwardsBranches
    {
        public static readonly int Sum;

        static TypeWithLotsOfBackwardsBranches()
        {
            int sum = 0;
            for (int i = 0; i < int.MaxValue / 2; i++)
                sum += i;
            Sum = sum;
        }
    }

    class TypeWithSomeBackwardsBranches
    {
        public static readonly int Sum;

        static TypeWithSomeBackwardsBranches()
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
                sum += i;
            Sum = sum;
        }
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(TypeWithLotsOfBackwardsBranches));
        Assert.AreEqual(-1610612735, TypeWithLotsOfBackwardsBranches.Sum);

        Assert.IsPreinitialized(typeof(TypeWithSomeBackwardsBranches));
        Assert.AreEqual(4950, TypeWithSomeBackwardsBranches.Sum);
    }
}

class TestDrawCircle
{
    static class CircleHolder
    {
        public static readonly byte[] s_bytes;

        static CircleHolder()
        {
            s_bytes = ComputeCircleBytes();
        }
    }

    private static byte[] ComputeCircleBytes()
    {
        const int Width = 16;

        byte[] bytes = new byte[Width * Width];
        for (int i = 0; i < bytes.Length; i++)
        {
            int x = i % Width;
            int y = i / Width;

            x -= Width / 2;
            y -= Width / 2;

            if (x * x + y * y < (Width / 2) * (Width / 2))
                bytes[i] = (byte)'*';
        }

        return bytes;
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(CircleHolder));

        byte[] expected = ComputeCircleBytes();
        byte[] actual = CircleHolder.s_bytes;

        Assert.AreEqual(expected.Length, actual.Length);

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], actual[i]);
        }
    }
}

class TestValueTypeDup
{
    class Dup
    {
        public static byte[] s_bytes;

        static Dup()
        {
            var bytes = new byte[2];
            int i = 0;
            while (i < 2)
            {
                bytes[i++] = 42;
            }
            s_bytes = bytes;
        }
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(Dup));

        Assert.AreEqual(2, Dup.s_bytes.Length);
        Assert.AreEqual(42, Dup.s_bytes[0]);
        Assert.AreEqual(42, Dup.s_bytes[1]);
    }
}

unsafe class TestFunctionPointers
{
    struct WithFunctionPointer
    {
        public void* Ptr;
        internal static WithFunctionPointer s_foo { get; } = new WithFunctionPointer() { Ptr = (delegate*<void>)&X };
        internal static void X() { }
    }

    public static void Run()
    {
        Assert.IsLazyInitialized(typeof(WithFunctionPointer));
        Assert.AreEqual(WithFunctionPointer.s_foo.Ptr, (delegate*<void>)&WithFunctionPointer.X);
    }
}

class TestGCInteraction
{
    class WithFrozenObjects
    {
        internal readonly static string s_someStringLiteral = "Some string literal";
        internal readonly static object s_someObject = new object();
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(WithFrozenObjects));

        var holder = new object[]
        {
            WithFrozenObjects.s_someStringLiteral,
            WithFrozenObjects.s_someObject,
        };

        var h1 = new DependentHandle(WithFrozenObjects.s_someObject, WithFrozenObjects.s_someStringLiteral);
        var h2 = new DependentHandle(WithFrozenObjects.s_someStringLiteral, WithFrozenObjects.s_someObject);

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Assert.AreSame(holder[0], WithFrozenObjects.s_someStringLiteral);
        Assert.AreSame(holder[1], WithFrozenObjects.s_someObject);

        h1.Dispose();
        h2.Dispose();
    }
}

class TestDuplicatedFields
{
    class WithSameFields
    {
        public static WithSameFields Field1a = new WithSameFields();
        public static WithSameFields Field1b = Field1a;

        public static int[] Field2a = new int[1];
        public static int[] Field2b = Field2a;
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(WithSameFields));
        Assert.AreSame(WithSameFields.Field1a, WithSameFields.Field1b);
        Assert.AreSame(WithSameFields.Field2a, WithSameFields.Field2b);
    }
}

class TestInstanceDelegate
{
    class ClassWithInstanceDelegate
    {
        public static Func<int> Instance1 = new ClassWithInstanceDelegate(42).GetCookie;
        public static ClassWithInstanceDelegate Target = new ClassWithInstanceDelegate(123);
        public static Func<int> Instance2 = Target.GetCookie;

        private int _cookie;
        public ClassWithInstanceDelegate(int cookie) => _cookie = cookie;
        public int GetCookie() => _cookie;
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(ClassWithInstanceDelegate));
        Assert.AreEqual(42, ClassWithInstanceDelegate.Instance1());
        Assert.AreEqual(123, ClassWithInstanceDelegate.Instance2());
        Assert.AreSame(ClassWithInstanceDelegate.Target, ClassWithInstanceDelegate.Instance2.Target);
    }
}

class TestStringFields
{
    class ClassAccessingLength
    {
        public static int Length = "Hello".Length;
    }

    class ClassAccessingNull
    {
        public static int Length;
        static ClassAccessingNull()
        {
            string myNull = null;
            try
            {
                Length = myNull.Length;
            }
            catch (Exception) { }
        }
    }

    public static void Run()
    {
        Assert.IsPreinitialized(typeof(ClassAccessingLength));
        Assert.AreEqual(5, ClassAccessingLength.Length);

        Assert.IsLazyInitialized(typeof(ClassAccessingNull));
        Assert.AreEqual(0, ClassAccessingNull.Length);
    }
}

class TestSharedCode
{
    class ClassWithTemplate<T>
    {
        public static int Cookie = 42;
        public static T[] Array = new T[0];
    }

    class C1 { }
    class C2 { }
    class C3 { }
    class C4 { }
    class C5 { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int AccessCookie<T>()
        => ClassWithTemplate<T>.Cookie;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object AccessArray<T>()
        => ClassWithTemplate<T>.Array;

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL3050:MakeGeneric",
        Justification = "MakeGeneric is over reference types")]
    public static void Run()
    {
        {
            int val = AccessCookie<C1>();
            Assert.AreEqual(42, val);

            val = (int)typeof(ClassWithTemplate<>).MakeGenericType(typeof(C2)).GetField("Cookie").GetValue(null);
            Assert.AreEqual(42, val);

            val = (int)typeof(TestSharedCode).GetMethod(nameof(AccessCookie)).MakeGenericMethod(typeof(C3)).Invoke(null, Array.Empty<object>());
            Assert.AreEqual(42, val);
        }

        {
            // Expecting this to be a frozen array, and reported as Gen2 by the GC
            object val = AccessArray<C1>();
            Assert.AreEqual(2, GC.GetGeneration(val));

            val = typeof(ClassWithTemplate<>).MakeGenericType(typeof(C4)).GetField("Array").GetValue(null);
            Assert.AreEqual(0, GC.GetGeneration(val));
            Assert.AreEqual(nameof(C4), val.GetType().GetElementType().Name);

            val = typeof(TestSharedCode).GetMethod(nameof(AccessArray)).MakeGenericMethod(typeof(C5)).Invoke(null, Array.Empty<object>());
            Assert.AreEqual(0, GC.GetGeneration(val));
            Assert.AreEqual(nameof(C5), val.GetType().GetElementType().Name);
        }
    }
}

static class Assert
{
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern",
        Justification = "Yep, we don't want to keep the cctor if it wasn't kept")]
    private static bool HasCctor(Type type)
    {
        return type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Static, null, Type.EmptyTypes, null) != null;
    }

    public static void IsPreinitialized(Type type)
    {
        if (HasCctor(type))
            throw new Exception();
    }

    public static void IsLazyInitialized(Type type)
    {
        if (!HasCctor(type))
            throw new Exception();
    }

    public static unsafe void AreEqual(void* v1, void* v2)
    {
        if (v1 != v2)
            throw new Exception();
    }

    public static unsafe void AreEqual(bool v1, bool v2)
    {
        if (v1 != v2)
            throw new Exception();
    }

    public static unsafe void AreEqual(int v1, int v2)
    {
        if (v1 != v2)
            throw new Exception();
    }

    public static void AreEqual(string v1, string v2)
    {
        if (v1 != v2)
            throw new Exception();
    }

    public static unsafe void AreEqual(long v1, long v2)
    {
        if (v1 != v2)
            throw new Exception();
    }

    public static unsafe void AreEqual(float v1, float v2)
    {
        if (v1 != v2)
            throw new Exception();
    }

    public static unsafe void AreEqual(double v1, double v2)
    {
        if (v1 != v2)
            throw new Exception();
    }

    public static void True(bool v)
    {
        if (!v)
            throw new Exception();
    }

    public static void AreSame<T>(T v1, T v2) where T : class
    {
        if (v1 != v2)
            throw new Exception();
    }
}
