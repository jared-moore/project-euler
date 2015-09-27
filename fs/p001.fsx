type System.Int32 with
    member x.divisibleBy y = x % y = 0

let max = 1000
seq { 0 .. max-1 } |> Seq.filter (fun n -> (n .divisibleBy 3 || n .divisibleBy 5)) |> Seq.sum