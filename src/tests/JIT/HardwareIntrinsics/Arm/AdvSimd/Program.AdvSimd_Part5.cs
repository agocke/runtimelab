// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;

namespace JIT.HardwareIntrinsics.Arm
{
    public static partial class Program
    {
        static Program()
        {
            TestList = new Dictionary<string, Action>() {
                ["ShiftRightAndInsert.Vector64.SByte"] = ShiftRightAndInsert_Vector64_SByte,
                ["ShiftRightAndInsert.Vector64.UInt16"] = ShiftRightAndInsert_Vector64_UInt16,
                ["ShiftRightAndInsert.Vector64.UInt32"] = ShiftRightAndInsert_Vector64_UInt32,
                ["ShiftRightAndInsert.Vector128.Byte"] = ShiftRightAndInsert_Vector128_Byte,
                ["ShiftRightAndInsert.Vector128.Int16"] = ShiftRightAndInsert_Vector128_Int16,
                ["ShiftRightAndInsert.Vector128.Int32"] = ShiftRightAndInsert_Vector128_Int32,
                ["ShiftRightAndInsert.Vector128.Int64"] = ShiftRightAndInsert_Vector128_Int64,
                ["ShiftRightAndInsert.Vector128.SByte"] = ShiftRightAndInsert_Vector128_SByte,
                ["ShiftRightAndInsert.Vector128.UInt16"] = ShiftRightAndInsert_Vector128_UInt16,
                ["ShiftRightAndInsert.Vector128.UInt32"] = ShiftRightAndInsert_Vector128_UInt32,
                ["ShiftRightAndInsert.Vector128.UInt64"] = ShiftRightAndInsert_Vector128_UInt64,
                ["ShiftRightAndInsertScalar.Vector64.Int64"] = ShiftRightAndInsertScalar_Vector64_Int64,
                ["ShiftRightAndInsertScalar.Vector64.UInt64"] = ShiftRightAndInsertScalar_Vector64_UInt64,
                ["ShiftRightArithmetic.Vector64.Int16.1"] = ShiftRightArithmetic_Vector64_Int16_1,
                ["ShiftRightArithmetic.Vector64.Int32.1"] = ShiftRightArithmetic_Vector64_Int32_1,
                ["ShiftRightArithmetic.Vector64.SByte.1"] = ShiftRightArithmetic_Vector64_SByte_1,
                ["ShiftRightArithmetic.Vector128.Int16.1"] = ShiftRightArithmetic_Vector128_Int16_1,
                ["ShiftRightArithmetic.Vector128.Int32.1"] = ShiftRightArithmetic_Vector128_Int32_1,
                ["ShiftRightArithmetic.Vector128.Int64.1"] = ShiftRightArithmetic_Vector128_Int64_1,
                ["ShiftRightArithmetic.Vector128.SByte.1"] = ShiftRightArithmetic_Vector128_SByte_1,
                ["ShiftRightArithmeticAdd.Vector64.Int16.1"] = ShiftRightArithmeticAdd_Vector64_Int16_1,
                ["ShiftRightArithmeticAdd.Vector64.Int32.1"] = ShiftRightArithmeticAdd_Vector64_Int32_1,
                ["ShiftRightArithmeticAdd.Vector64.SByte.1"] = ShiftRightArithmeticAdd_Vector64_SByte_1,
                ["ShiftRightArithmeticAdd.Vector128.Int16.1"] = ShiftRightArithmeticAdd_Vector128_Int16_1,
                ["ShiftRightArithmeticAdd.Vector128.Int32.1"] = ShiftRightArithmeticAdd_Vector128_Int32_1,
                ["ShiftRightArithmeticAdd.Vector128.Int64.1"] = ShiftRightArithmeticAdd_Vector128_Int64_1,
                ["ShiftRightArithmeticAdd.Vector128.SByte.1"] = ShiftRightArithmeticAdd_Vector128_SByte_1,
                ["ShiftRightArithmeticAddScalar.Vector64.Int64.1"] = ShiftRightArithmeticAddScalar_Vector64_Int64_1,
                ["ShiftRightArithmeticNarrowingSaturateLower.Vector64.Int16.1"] = ShiftRightArithmeticNarrowingSaturateLower_Vector64_Int16_1,
                ["ShiftRightArithmeticNarrowingSaturateLower.Vector64.Int32.1"] = ShiftRightArithmeticNarrowingSaturateLower_Vector64_Int32_1,
                ["ShiftRightArithmeticNarrowingSaturateLower.Vector64.SByte.1"] = ShiftRightArithmeticNarrowingSaturateLower_Vector64_SByte_1,
                ["ShiftRightArithmeticNarrowingSaturateUnsignedLower.Vector64.Byte.1"] = ShiftRightArithmeticNarrowingSaturateUnsignedLower_Vector64_Byte_1,
                ["ShiftRightArithmeticNarrowingSaturateUnsignedLower.Vector64.UInt16.1"] = ShiftRightArithmeticNarrowingSaturateUnsignedLower_Vector64_UInt16_1,
                ["ShiftRightArithmeticNarrowingSaturateUnsignedLower.Vector64.UInt32.1"] = ShiftRightArithmeticNarrowingSaturateUnsignedLower_Vector64_UInt32_1,
                ["ShiftRightArithmeticNarrowingSaturateUnsignedUpper.Vector128.Byte.1"] = ShiftRightArithmeticNarrowingSaturateUnsignedUpper_Vector128_Byte_1,
                ["ShiftRightArithmeticNarrowingSaturateUnsignedUpper.Vector128.UInt16.1"] = ShiftRightArithmeticNarrowingSaturateUnsignedUpper_Vector128_UInt16_1,
                ["ShiftRightArithmeticNarrowingSaturateUnsignedUpper.Vector128.UInt32.1"] = ShiftRightArithmeticNarrowingSaturateUnsignedUpper_Vector128_UInt32_1,
                ["ShiftRightArithmeticNarrowingSaturateUpper.Vector128.Int16.1"] = ShiftRightArithmeticNarrowingSaturateUpper_Vector128_Int16_1,
                ["ShiftRightArithmeticNarrowingSaturateUpper.Vector128.Int32.1"] = ShiftRightArithmeticNarrowingSaturateUpper_Vector128_Int32_1,
                ["ShiftRightArithmeticNarrowingSaturateUpper.Vector128.SByte.1"] = ShiftRightArithmeticNarrowingSaturateUpper_Vector128_SByte_1,
                ["ShiftRightArithmeticRounded.Vector64.Int16.1"] = ShiftRightArithmeticRounded_Vector64_Int16_1,
                ["ShiftRightArithmeticRounded.Vector64.Int32.1"] = ShiftRightArithmeticRounded_Vector64_Int32_1,
                ["ShiftRightArithmeticRounded.Vector64.SByte.1"] = ShiftRightArithmeticRounded_Vector64_SByte_1,
                ["ShiftRightArithmeticRounded.Vector128.Int16.1"] = ShiftRightArithmeticRounded_Vector128_Int16_1,
                ["ShiftRightArithmeticRounded.Vector128.Int32.1"] = ShiftRightArithmeticRounded_Vector128_Int32_1,
                ["ShiftRightArithmeticRounded.Vector128.Int64.1"] = ShiftRightArithmeticRounded_Vector128_Int64_1,
                ["ShiftRightArithmeticRounded.Vector128.SByte.1"] = ShiftRightArithmeticRounded_Vector128_SByte_1,
                ["ShiftRightArithmeticRoundedAdd.Vector64.Int16.1"] = ShiftRightArithmeticRoundedAdd_Vector64_Int16_1,
                ["ShiftRightArithmeticRoundedAdd.Vector64.Int32.1"] = ShiftRightArithmeticRoundedAdd_Vector64_Int32_1,
                ["ShiftRightArithmeticRoundedAdd.Vector64.SByte.1"] = ShiftRightArithmeticRoundedAdd_Vector64_SByte_1,
                ["ShiftRightArithmeticRoundedAdd.Vector128.Int16.1"] = ShiftRightArithmeticRoundedAdd_Vector128_Int16_1,
                ["ShiftRightArithmeticRoundedAdd.Vector128.Int32.1"] = ShiftRightArithmeticRoundedAdd_Vector128_Int32_1,
                ["ShiftRightArithmeticRoundedAdd.Vector128.Int64.1"] = ShiftRightArithmeticRoundedAdd_Vector128_Int64_1,
                ["ShiftRightArithmeticRoundedAdd.Vector128.SByte.1"] = ShiftRightArithmeticRoundedAdd_Vector128_SByte_1,
                ["ShiftRightArithmeticRoundedAddScalar.Vector64.Int64.1"] = ShiftRightArithmeticRoundedAddScalar_Vector64_Int64_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateLower.Vector64.Int16.1"] = ShiftRightArithmeticRoundedNarrowingSaturateLower_Vector64_Int16_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateLower.Vector64.Int32.1"] = ShiftRightArithmeticRoundedNarrowingSaturateLower_Vector64_Int32_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateLower.Vector64.SByte.1"] = ShiftRightArithmeticRoundedNarrowingSaturateLower_Vector64_SByte_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower.Vector64.Byte.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower_Vector64_Byte_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower.Vector64.UInt16.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower_Vector64_UInt16_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower.Vector64.UInt32.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower_Vector64_UInt32_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper.Vector128.Byte.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper_Vector128_Byte_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper.Vector128.UInt16.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper_Vector128_UInt16_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper.Vector128.UInt32.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper_Vector128_UInt32_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUpper.Vector128.Int16.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUpper_Vector128_Int16_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUpper.Vector128.Int32.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUpper_Vector128_Int32_1,
                ["ShiftRightArithmeticRoundedNarrowingSaturateUpper.Vector128.SByte.1"] = ShiftRightArithmeticRoundedNarrowingSaturateUpper_Vector128_SByte_1,
                ["ShiftRightArithmeticRoundedScalar.Vector64.Int64.1"] = ShiftRightArithmeticRoundedScalar_Vector64_Int64_1,
                ["ShiftRightArithmeticScalar.Vector64.Int64.1"] = ShiftRightArithmeticScalar_Vector64_Int64_1,
                ["ShiftRightLogical.Vector64.Byte.1"] = ShiftRightLogical_Vector64_Byte_1,
                ["ShiftRightLogical.Vector64.Int16.1"] = ShiftRightLogical_Vector64_Int16_1,
                ["ShiftRightLogical.Vector64.Int32.1"] = ShiftRightLogical_Vector64_Int32_1,
                ["ShiftRightLogical.Vector64.SByte.1"] = ShiftRightLogical_Vector64_SByte_1,
                ["ShiftRightLogical.Vector64.UInt16.1"] = ShiftRightLogical_Vector64_UInt16_1,
                ["ShiftRightLogical.Vector64.UInt32.1"] = ShiftRightLogical_Vector64_UInt32_1,
                ["ShiftRightLogical.Vector128.Byte.1"] = ShiftRightLogical_Vector128_Byte_1,
                ["ShiftRightLogical.Vector128.Int16.1"] = ShiftRightLogical_Vector128_Int16_1,
                ["ShiftRightLogical.Vector128.Int32.1"] = ShiftRightLogical_Vector128_Int32_1,
                ["ShiftRightLogical.Vector128.Int64.1"] = ShiftRightLogical_Vector128_Int64_1,
                ["ShiftRightLogical.Vector128.SByte.1"] = ShiftRightLogical_Vector128_SByte_1,
                ["ShiftRightLogical.Vector128.UInt16.1"] = ShiftRightLogical_Vector128_UInt16_1,
                ["ShiftRightLogical.Vector128.UInt32.1"] = ShiftRightLogical_Vector128_UInt32_1,
                ["ShiftRightLogical.Vector128.UInt64.1"] = ShiftRightLogical_Vector128_UInt64_1,
                ["ShiftRightLogicalAdd.Vector64.Byte.1"] = ShiftRightLogicalAdd_Vector64_Byte_1,
                ["ShiftRightLogicalAdd.Vector64.Int16.1"] = ShiftRightLogicalAdd_Vector64_Int16_1,
                ["ShiftRightLogicalAdd.Vector64.Int32.1"] = ShiftRightLogicalAdd_Vector64_Int32_1,
                ["ShiftRightLogicalAdd.Vector64.SByte.1"] = ShiftRightLogicalAdd_Vector64_SByte_1,
                ["ShiftRightLogicalAdd.Vector64.UInt16.1"] = ShiftRightLogicalAdd_Vector64_UInt16_1,
                ["ShiftRightLogicalAdd.Vector64.UInt32.1"] = ShiftRightLogicalAdd_Vector64_UInt32_1,
                ["ShiftRightLogicalAdd.Vector128.Byte.1"] = ShiftRightLogicalAdd_Vector128_Byte_1,
                ["ShiftRightLogicalAdd.Vector128.Int16.1"] = ShiftRightLogicalAdd_Vector128_Int16_1,
                ["ShiftRightLogicalAdd.Vector128.Int32.1"] = ShiftRightLogicalAdd_Vector128_Int32_1,
                ["ShiftRightLogicalAdd.Vector128.Int64.1"] = ShiftRightLogicalAdd_Vector128_Int64_1,
                ["ShiftRightLogicalAdd.Vector128.SByte.1"] = ShiftRightLogicalAdd_Vector128_SByte_1,
                ["ShiftRightLogicalAdd.Vector128.UInt16.1"] = ShiftRightLogicalAdd_Vector128_UInt16_1,
                ["ShiftRightLogicalAdd.Vector128.UInt32.1"] = ShiftRightLogicalAdd_Vector128_UInt32_1,
                ["ShiftRightLogicalAdd.Vector128.UInt64.1"] = ShiftRightLogicalAdd_Vector128_UInt64_1,
                ["ShiftRightLogicalAddScalar.Vector64.Int64.1"] = ShiftRightLogicalAddScalar_Vector64_Int64_1,
                ["ShiftRightLogicalAddScalar.Vector64.UInt64.1"] = ShiftRightLogicalAddScalar_Vector64_UInt64_1,
                ["ShiftRightLogicalNarrowingLower.Vector64.Byte.1"] = ShiftRightLogicalNarrowingLower_Vector64_Byte_1,
                ["ShiftRightLogicalNarrowingLower.Vector64.Int16.1"] = ShiftRightLogicalNarrowingLower_Vector64_Int16_1,
                ["ShiftRightLogicalNarrowingLower.Vector64.Int32.1"] = ShiftRightLogicalNarrowingLower_Vector64_Int32_1,
                ["ShiftRightLogicalNarrowingLower.Vector64.SByte.1"] = ShiftRightLogicalNarrowingLower_Vector64_SByte_1,
                ["ShiftRightLogicalNarrowingLower.Vector64.UInt16.1"] = ShiftRightLogicalNarrowingLower_Vector64_UInt16_1,
                ["ShiftRightLogicalNarrowingLower.Vector64.UInt32.1"] = ShiftRightLogicalNarrowingLower_Vector64_UInt32_1,
                ["ShiftRightLogicalNarrowingSaturateLower.Vector64.Byte.1"] = ShiftRightLogicalNarrowingSaturateLower_Vector64_Byte_1,
                ["ShiftRightLogicalNarrowingSaturateLower.Vector64.Int16.1"] = ShiftRightLogicalNarrowingSaturateLower_Vector64_Int16_1,
                ["ShiftRightLogicalNarrowingSaturateLower.Vector64.Int32.1"] = ShiftRightLogicalNarrowingSaturateLower_Vector64_Int32_1,
                ["ShiftRightLogicalNarrowingSaturateLower.Vector64.SByte.1"] = ShiftRightLogicalNarrowingSaturateLower_Vector64_SByte_1,
                ["ShiftRightLogicalNarrowingSaturateLower.Vector64.UInt16.1"] = ShiftRightLogicalNarrowingSaturateLower_Vector64_UInt16_1,
                ["ShiftRightLogicalNarrowingSaturateLower.Vector64.UInt32.1"] = ShiftRightLogicalNarrowingSaturateLower_Vector64_UInt32_1,
                ["ShiftRightLogicalNarrowingSaturateUpper.Vector128.Byte.1"] = ShiftRightLogicalNarrowingSaturateUpper_Vector128_Byte_1,
                ["ShiftRightLogicalNarrowingSaturateUpper.Vector128.Int16.1"] = ShiftRightLogicalNarrowingSaturateUpper_Vector128_Int16_1,
                ["ShiftRightLogicalNarrowingSaturateUpper.Vector128.Int32.1"] = ShiftRightLogicalNarrowingSaturateUpper_Vector128_Int32_1,
                ["ShiftRightLogicalNarrowingSaturateUpper.Vector128.SByte.1"] = ShiftRightLogicalNarrowingSaturateUpper_Vector128_SByte_1,
                ["ShiftRightLogicalNarrowingSaturateUpper.Vector128.UInt16.1"] = ShiftRightLogicalNarrowingSaturateUpper_Vector128_UInt16_1,
                ["ShiftRightLogicalNarrowingSaturateUpper.Vector128.UInt32.1"] = ShiftRightLogicalNarrowingSaturateUpper_Vector128_UInt32_1,
                ["ShiftRightLogicalNarrowingUpper.Vector128.Byte.1"] = ShiftRightLogicalNarrowingUpper_Vector128_Byte_1,
                ["ShiftRightLogicalNarrowingUpper.Vector128.Int16.1"] = ShiftRightLogicalNarrowingUpper_Vector128_Int16_1,
                ["ShiftRightLogicalNarrowingUpper.Vector128.Int32.1"] = ShiftRightLogicalNarrowingUpper_Vector128_Int32_1,
                ["ShiftRightLogicalNarrowingUpper.Vector128.SByte.1"] = ShiftRightLogicalNarrowingUpper_Vector128_SByte_1,
                ["ShiftRightLogicalNarrowingUpper.Vector128.UInt16.1"] = ShiftRightLogicalNarrowingUpper_Vector128_UInt16_1,
                ["ShiftRightLogicalNarrowingUpper.Vector128.UInt32.1"] = ShiftRightLogicalNarrowingUpper_Vector128_UInt32_1,
                ["ShiftRightLogicalRounded.Vector64.Byte.1"] = ShiftRightLogicalRounded_Vector64_Byte_1,
                ["ShiftRightLogicalRounded.Vector64.Int16.1"] = ShiftRightLogicalRounded_Vector64_Int16_1,
                ["ShiftRightLogicalRounded.Vector64.Int32.1"] = ShiftRightLogicalRounded_Vector64_Int32_1,
                ["ShiftRightLogicalRounded.Vector64.SByte.1"] = ShiftRightLogicalRounded_Vector64_SByte_1,
                ["ShiftRightLogicalRounded.Vector64.UInt16.1"] = ShiftRightLogicalRounded_Vector64_UInt16_1,
                ["ShiftRightLogicalRounded.Vector64.UInt32.1"] = ShiftRightLogicalRounded_Vector64_UInt32_1,
                ["ShiftRightLogicalRounded.Vector128.Byte.1"] = ShiftRightLogicalRounded_Vector128_Byte_1,
                ["ShiftRightLogicalRounded.Vector128.Int16.1"] = ShiftRightLogicalRounded_Vector128_Int16_1,
                ["ShiftRightLogicalRounded.Vector128.Int32.1"] = ShiftRightLogicalRounded_Vector128_Int32_1,
                ["ShiftRightLogicalRounded.Vector128.Int64.1"] = ShiftRightLogicalRounded_Vector128_Int64_1,
                ["ShiftRightLogicalRounded.Vector128.SByte.1"] = ShiftRightLogicalRounded_Vector128_SByte_1,
                ["ShiftRightLogicalRounded.Vector128.UInt16.1"] = ShiftRightLogicalRounded_Vector128_UInt16_1,
                ["ShiftRightLogicalRounded.Vector128.UInt32.1"] = ShiftRightLogicalRounded_Vector128_UInt32_1,
                ["ShiftRightLogicalRounded.Vector128.UInt64.1"] = ShiftRightLogicalRounded_Vector128_UInt64_1,
                ["ShiftRightLogicalRoundedAdd.Vector64.Byte.1"] = ShiftRightLogicalRoundedAdd_Vector64_Byte_1,
                ["ShiftRightLogicalRoundedAdd.Vector64.Int16.1"] = ShiftRightLogicalRoundedAdd_Vector64_Int16_1,
                ["ShiftRightLogicalRoundedAdd.Vector64.Int32.1"] = ShiftRightLogicalRoundedAdd_Vector64_Int32_1,
                ["ShiftRightLogicalRoundedAdd.Vector64.SByte.1"] = ShiftRightLogicalRoundedAdd_Vector64_SByte_1,
                ["ShiftRightLogicalRoundedAdd.Vector64.UInt16.1"] = ShiftRightLogicalRoundedAdd_Vector64_UInt16_1,
                ["ShiftRightLogicalRoundedAdd.Vector64.UInt32.1"] = ShiftRightLogicalRoundedAdd_Vector64_UInt32_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.Byte.1"] = ShiftRightLogicalRoundedAdd_Vector128_Byte_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.Int16.1"] = ShiftRightLogicalRoundedAdd_Vector128_Int16_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.Int32.1"] = ShiftRightLogicalRoundedAdd_Vector128_Int32_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.Int64.1"] = ShiftRightLogicalRoundedAdd_Vector128_Int64_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.SByte.1"] = ShiftRightLogicalRoundedAdd_Vector128_SByte_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.UInt16.1"] = ShiftRightLogicalRoundedAdd_Vector128_UInt16_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.UInt32.1"] = ShiftRightLogicalRoundedAdd_Vector128_UInt32_1,
                ["ShiftRightLogicalRoundedAdd.Vector128.UInt64.1"] = ShiftRightLogicalRoundedAdd_Vector128_UInt64_1,
                ["ShiftRightLogicalRoundedAddScalar.Vector64.Int64.1"] = ShiftRightLogicalRoundedAddScalar_Vector64_Int64_1,
                ["ShiftRightLogicalRoundedAddScalar.Vector64.UInt64.1"] = ShiftRightLogicalRoundedAddScalar_Vector64_UInt64_1,
                ["ShiftRightLogicalRoundedNarrowingLower.Vector64.Byte.1"] = ShiftRightLogicalRoundedNarrowingLower_Vector64_Byte_1,
                ["ShiftRightLogicalRoundedNarrowingLower.Vector64.Int16.1"] = ShiftRightLogicalRoundedNarrowingLower_Vector64_Int16_1,
                ["ShiftRightLogicalRoundedNarrowingLower.Vector64.Int32.1"] = ShiftRightLogicalRoundedNarrowingLower_Vector64_Int32_1,
                ["ShiftRightLogicalRoundedNarrowingLower.Vector64.SByte.1"] = ShiftRightLogicalRoundedNarrowingLower_Vector64_SByte_1,
                ["ShiftRightLogicalRoundedNarrowingLower.Vector64.UInt16.1"] = ShiftRightLogicalRoundedNarrowingLower_Vector64_UInt16_1,
                ["ShiftRightLogicalRoundedNarrowingLower.Vector64.UInt32.1"] = ShiftRightLogicalRoundedNarrowingLower_Vector64_UInt32_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateLower.Vector64.Byte.1"] = ShiftRightLogicalRoundedNarrowingSaturateLower_Vector64_Byte_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateLower.Vector64.Int16.1"] = ShiftRightLogicalRoundedNarrowingSaturateLower_Vector64_Int16_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateLower.Vector64.Int32.1"] = ShiftRightLogicalRoundedNarrowingSaturateLower_Vector64_Int32_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateLower.Vector64.SByte.1"] = ShiftRightLogicalRoundedNarrowingSaturateLower_Vector64_SByte_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateLower.Vector64.UInt16.1"] = ShiftRightLogicalRoundedNarrowingSaturateLower_Vector64_UInt16_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateLower.Vector64.UInt32.1"] = ShiftRightLogicalRoundedNarrowingSaturateLower_Vector64_UInt32_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateUpper.Vector128.Byte.1"] = ShiftRightLogicalRoundedNarrowingSaturateUpper_Vector128_Byte_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateUpper.Vector128.Int16.1"] = ShiftRightLogicalRoundedNarrowingSaturateUpper_Vector128_Int16_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateUpper.Vector128.Int32.1"] = ShiftRightLogicalRoundedNarrowingSaturateUpper_Vector128_Int32_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateUpper.Vector128.SByte.1"] = ShiftRightLogicalRoundedNarrowingSaturateUpper_Vector128_SByte_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateUpper.Vector128.UInt16.1"] = ShiftRightLogicalRoundedNarrowingSaturateUpper_Vector128_UInt16_1,
                ["ShiftRightLogicalRoundedNarrowingSaturateUpper.Vector128.UInt32.1"] = ShiftRightLogicalRoundedNarrowingSaturateUpper_Vector128_UInt32_1,
                ["ShiftRightLogicalRoundedNarrowingUpper.Vector128.Byte.1"] = ShiftRightLogicalRoundedNarrowingUpper_Vector128_Byte_1,
                ["ShiftRightLogicalRoundedNarrowingUpper.Vector128.Int16.1"] = ShiftRightLogicalRoundedNarrowingUpper_Vector128_Int16_1,
                ["ShiftRightLogicalRoundedNarrowingUpper.Vector128.Int32.1"] = ShiftRightLogicalRoundedNarrowingUpper_Vector128_Int32_1,
                ["ShiftRightLogicalRoundedNarrowingUpper.Vector128.SByte.1"] = ShiftRightLogicalRoundedNarrowingUpper_Vector128_SByte_1,
                ["ShiftRightLogicalRoundedNarrowingUpper.Vector128.UInt16.1"] = ShiftRightLogicalRoundedNarrowingUpper_Vector128_UInt16_1,
                ["ShiftRightLogicalRoundedNarrowingUpper.Vector128.UInt32.1"] = ShiftRightLogicalRoundedNarrowingUpper_Vector128_UInt32_1,
                ["ShiftRightLogicalRoundedScalar.Vector64.Int64.1"] = ShiftRightLogicalRoundedScalar_Vector64_Int64_1,
                ["ShiftRightLogicalRoundedScalar.Vector64.UInt64.1"] = ShiftRightLogicalRoundedScalar_Vector64_UInt64_1,
                ["ShiftRightLogicalScalar.Vector64.Int64.1"] = ShiftRightLogicalScalar_Vector64_Int64_1,
                ["ShiftRightLogicalScalar.Vector64.UInt64.1"] = ShiftRightLogicalScalar_Vector64_UInt64_1,
                ["SignExtendWideningLower.Vector64.Int16"] = SignExtendWideningLower_Vector64_Int16,
                ["SignExtendWideningLower.Vector64.Int32"] = SignExtendWideningLower_Vector64_Int32,
                ["SignExtendWideningLower.Vector64.SByte"] = SignExtendWideningLower_Vector64_SByte,
                ["SignExtendWideningUpper.Vector128.Int16"] = SignExtendWideningUpper_Vector128_Int16,
                ["SignExtendWideningUpper.Vector128.Int32"] = SignExtendWideningUpper_Vector128_Int32,
                ["SignExtendWideningUpper.Vector128.SByte"] = SignExtendWideningUpper_Vector128_SByte,
                ["SqrtScalar.Vector64.Double"] = SqrtScalar_Vector64_Double,
                ["SqrtScalar.Vector64.Single"] = SqrtScalar_Vector64_Single,
                ["Store.Vector64.Byte"] = Store_Vector64_Byte,
                ["Store.Vector64.Double"] = Store_Vector64_Double,
                ["Store.Vector64.Int16"] = Store_Vector64_Int16,
                ["Store.Vector64.Int32"] = Store_Vector64_Int32,
                ["Store.Vector64.Int64"] = Store_Vector64_Int64,
                ["Store.Vector64.SByte"] = Store_Vector64_SByte,
                ["Store.Vector64.Single"] = Store_Vector64_Single,
                ["Store.Vector64.UInt16"] = Store_Vector64_UInt16,
                ["Store.Vector64.UInt32"] = Store_Vector64_UInt32,
                ["Store.Vector64.UInt64"] = Store_Vector64_UInt64,
                ["Store.Vector128.Byte"] = Store_Vector128_Byte,
                ["Store.Vector128.Double"] = Store_Vector128_Double,
                ["Store.Vector128.Int16"] = Store_Vector128_Int16,
                ["Store.Vector128.Int32"] = Store_Vector128_Int32,
                ["Store.Vector128.Int64"] = Store_Vector128_Int64,
                ["Store.Vector128.SByte"] = Store_Vector128_SByte,
                ["Store.Vector128.Single"] = Store_Vector128_Single,
                ["Store.Vector128.UInt16"] = Store_Vector128_UInt16,
                ["Store.Vector128.UInt32"] = Store_Vector128_UInt32,
                ["Store.Vector128.UInt64"] = Store_Vector128_UInt64,
                ["StoreSelectedScalar.Vector64.Byte.7"] = StoreSelectedScalar_Vector64_Byte_7,
                ["StoreSelectedScalar.Vector64.Int16.3"] = StoreSelectedScalar_Vector64_Int16_3,
                ["StoreSelectedScalar.Vector64.Int32.1"] = StoreSelectedScalar_Vector64_Int32_1,
                ["StoreSelectedScalar.Vector64.SByte.7"] = StoreSelectedScalar_Vector64_SByte_7,
                ["StoreSelectedScalar.Vector64.Single.1"] = StoreSelectedScalar_Vector64_Single_1,
                ["StoreSelectedScalar.Vector64.UInt16.3"] = StoreSelectedScalar_Vector64_UInt16_3,
                ["StoreSelectedScalar.Vector64.UInt32.1"] = StoreSelectedScalar_Vector64_UInt32_1,
                ["StoreSelectedScalar.Vector128.Byte.15"] = StoreSelectedScalar_Vector128_Byte_15,
                ["StoreSelectedScalar.Vector128.Double.1"] = StoreSelectedScalar_Vector128_Double_1,
                ["StoreSelectedScalar.Vector128.Int16.7"] = StoreSelectedScalar_Vector128_Int16_7,
                ["StoreSelectedScalar.Vector128.Int32.3"] = StoreSelectedScalar_Vector128_Int32_3,
                ["StoreSelectedScalar.Vector128.Int64.1"] = StoreSelectedScalar_Vector128_Int64_1,
                ["StoreSelectedScalar.Vector128.SByte.15"] = StoreSelectedScalar_Vector128_SByte_15,
                ["StoreSelectedScalar.Vector128.Single.3"] = StoreSelectedScalar_Vector128_Single_3,
                ["StoreSelectedScalar.Vector128.UInt16.7"] = StoreSelectedScalar_Vector128_UInt16_7,
                ["StoreSelectedScalar.Vector128.UInt32.3"] = StoreSelectedScalar_Vector128_UInt32_3,
                ["StoreSelectedScalar.Vector128.UInt64.1"] = StoreSelectedScalar_Vector128_UInt64_1,
                ["Subtract.Vector64.Byte"] = Subtract_Vector64_Byte,
                ["Subtract.Vector64.Int16"] = Subtract_Vector64_Int16,
                ["Subtract.Vector64.Int32"] = Subtract_Vector64_Int32,
                ["Subtract.Vector64.SByte"] = Subtract_Vector64_SByte,
                ["Subtract.Vector64.Single"] = Subtract_Vector64_Single,
                ["Subtract.Vector64.UInt16"] = Subtract_Vector64_UInt16,
                ["Subtract.Vector64.UInt32"] = Subtract_Vector64_UInt32,
                ["Subtract.Vector128.Byte"] = Subtract_Vector128_Byte,
                ["Subtract.Vector128.Int16"] = Subtract_Vector128_Int16,
                ["Subtract.Vector128.Int32"] = Subtract_Vector128_Int32,
                ["Subtract.Vector128.Int64"] = Subtract_Vector128_Int64,
                ["Subtract.Vector128.SByte"] = Subtract_Vector128_SByte,
                ["Subtract.Vector128.Single"] = Subtract_Vector128_Single,
                ["Subtract.Vector128.UInt16"] = Subtract_Vector128_UInt16,
                ["Subtract.Vector128.UInt32"] = Subtract_Vector128_UInt32,
                ["Subtract.Vector128.UInt64"] = Subtract_Vector128_UInt64,
                ["SubtractHighNarrowingLower.Vector64.Byte"] = SubtractHighNarrowingLower_Vector64_Byte,
                ["SubtractHighNarrowingLower.Vector64.Int16"] = SubtractHighNarrowingLower_Vector64_Int16,
                ["SubtractHighNarrowingLower.Vector64.Int32"] = SubtractHighNarrowingLower_Vector64_Int32,
                ["SubtractHighNarrowingLower.Vector64.SByte"] = SubtractHighNarrowingLower_Vector64_SByte,
                ["SubtractHighNarrowingLower.Vector64.UInt16"] = SubtractHighNarrowingLower_Vector64_UInt16,
                ["SubtractHighNarrowingLower.Vector64.UInt32"] = SubtractHighNarrowingLower_Vector64_UInt32,
                ["SubtractHighNarrowingUpper.Vector128.Byte"] = SubtractHighNarrowingUpper_Vector128_Byte,
                ["SubtractHighNarrowingUpper.Vector128.Int16"] = SubtractHighNarrowingUpper_Vector128_Int16,
                ["SubtractHighNarrowingUpper.Vector128.Int32"] = SubtractHighNarrowingUpper_Vector128_Int32,
                ["SubtractHighNarrowingUpper.Vector128.SByte"] = SubtractHighNarrowingUpper_Vector128_SByte,
                ["SubtractHighNarrowingUpper.Vector128.UInt16"] = SubtractHighNarrowingUpper_Vector128_UInt16,
                ["SubtractHighNarrowingUpper.Vector128.UInt32"] = SubtractHighNarrowingUpper_Vector128_UInt32,
                ["SubtractRoundedHighNarrowingLower.Vector64.Byte"] = SubtractRoundedHighNarrowingLower_Vector64_Byte,
                ["SubtractRoundedHighNarrowingLower.Vector64.Int16"] = SubtractRoundedHighNarrowingLower_Vector64_Int16,
            };
        }
    }
}
