let primesLessThan n = 
    // Candidate primes. Some means it may be prime, None means we have crossed it out.
    let candidates = [| for i in 2 .. n -> Some i |]
    for candidateIndex in 0 .. candidates.Length - 1  do
        match candidates.[candidateIndex] with
            | None           -> () // Already crossed out
            | Some candidate -> // Cross out multiples of candidate
                                let crossOutIndexes = seq { (candidateIndex + candidate) .. candidate .. (candidates.Length - 1) }
                                for xo in crossOutIndexes do
                                candidates.[xo] <- None
    // Return the elements that are Some
    candidates |> Seq.choose id |> Seq.toList

//// Naive and inefficient PseudoSieve function
//let rec PseudoSieve list =
//    match list with
//    | hd::tl -> hd :: (PseudoSieve <| List.filter (fun x -> x % hd <> 0) tl)
//    | [] -> []
//
//let primesLessThan2 n = PseudoSieve (List.ofSeq { 2 .. n })
//
//let duration f = 
//    let timer = new System.Diagnostics.Stopwatch()
//    timer.Start()
//    let returnValue = f()
//    printfn "Elapsed Time: %i" timer.ElapsedMilliseconds
//    returnValue
//
//duration (fun() -> primesLessThan 100000)
//duration (fun() -> primesLessThan2 100000)

let intSqrt (x: int64) : int = int (System.Math.Sqrt (double x))

let primeFactors n = 
    primesLessThan (intSqrt n)
    |> Seq.filter (fun i -> n % (int64 i) = 0L)
    |> Seq.toList

let largestPrimeFactor n = primeFactors n |> Seq.last

largestPrimeFactor 600851475143L
