let max = 4000000

// Functional solution
let fibs = 
    Seq.unfold 
        (fun (a, b) -> Some (a, (b, a + b)))
        (1, 2)

fibs |> Seq.takeWhile (fun n -> n < max)
     |> Seq.filter (fun n -> n % 2 = 0)
     |> Seq.sum

// Procedural solution
//open System.Linq
//
//let fibs = System.Collections.Generic.List<int>()
//fibs.Add 1
//fibs.Add 2
//while fibs.Last() < max do
//    fibs.Add (fibs.Item (fibs.Count-1) + fibs.Item (fibs.Count-2))
//
//fibs |> Seq.where (fun n -> n % 2 = 0) |> Seq.sum