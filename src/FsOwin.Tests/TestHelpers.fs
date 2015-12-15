[<AutoOpen>]
module TestHelpers

open NUnit.Framework

let private assrt assertion actual expected = assertion (box expected, box actual, sprintf "Expected: %+A\rActual: %+A" expected actual)
let (==) actual expected = assrt Assert.AreEqual actual expected
let (!=) actual expected = assrt Assert.AreNotEqual actual expected

type Test = TestAttribute