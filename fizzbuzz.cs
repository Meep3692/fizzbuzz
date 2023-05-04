List<Mutator<int, String>> mutators = new List<Mutator<int, String>> {
    new Mutator<int, String> {
        Predicate = i => i % 3 == 0,
        Mutate = i => "fizz"
    },
    new Mutator<int, String> {
        Predicate = i => i % 5 == 0,
        Mutate = i => "buzz"
    }
};

Enumerable.Range(1,100).Select(i => mutators.Any(m => m.Predicate(i)) ? mutators.Where(m => m.Predicate(i)).Select(m => m.Mutate(i)).Aggregate((a, b) => a + b) : i.ToString()).ToList().ForEach(Console.WriteLine);

struct Mutator<T1, T2> {
    public Func<T1, bool> Predicate { get; set; }
    public Func<T1, T2> Mutate { get; set; }
}
