using System;

public enum Bucket
{
    One,
    Two
}

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}

public class BucketMeasure
{
    public int Capacity { get; }
    public int Filled { get; set; }

    public BucketMeasure(int capacity, int fill)
    {
        Capacity = capacity; Filled = fill;
    }

    public void Emptying() => Filled = 0;
    public void Initialize() => Filled = Capacity;
}

public class TwoBucket
{
    private BucketMeasure _first;
    private BucketMeasure _second;
    private int _moves = 0;
    private readonly Bucket _startBucket;

    public readonly TwoBucketResult result = new TwoBucketResult();
    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        _first = new BucketMeasure(bucketOne, 0);
        _second = new BucketMeasure(bucketTwo, 0);
        _startBucket = startBucket;

    }

    public TwoBucketResult Measure(int goal)
    {
        TwoBucketResult twoBucketResult = Bucket.One == _startBucket ? StartFind(ref _first, ref _second, goal) : StartFind(ref _second, ref _first, goal);
        return twoBucketResult;
    }
    private TwoBucketResult StartFind(ref BucketMeasure first, ref BucketMeasure second, int goal)
    {

        //if first step we make fill up target
        if (first.Filled == 0)
        {
            first.Initialize();
            _moves++;
            if (_first.Filled == goal)
                return new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.One, OtherBucket = _second.Filled };

            if (_second.Filled == goal)
                return new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.Two, OtherBucket = _first.Filled };
        }
        //if both empty, check bucket, then fill better

        if ((first.Filled == 0 || second.Filled == 0) && _moves > 0)
        {
            if (first.Capacity == goal)
            {
                first.Initialize();
                _moves++;
                if (first.Filled == goal)
                    return new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.One, OtherBucket = _second.Filled };
            }
            else if (second.Capacity == goal)
            {
                second.Initialize();
                _moves++;
                return new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.Two, OtherBucket = _first.Filled };
            }
        }



        int free = Math.Min(second.Capacity - second.Filled, first.Filled);
        if (second.Capacity - second.Filled == 0)
        {
            if (_second.Filled == goal)
                return new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.Two, OtherBucket = _first.Filled };
            second.Emptying();
            _moves++;
        }
        else
        {
            second.Filled += free;
            first.Filled -= free;
            _moves++;
            if (_first.Filled == goal)
                return new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.One, OtherBucket = _second.Filled };

            if (_second.Filled == goal)
                return new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.Two, OtherBucket = _first.Filled };
        }

        if (_first.Filled != goal || _second.Filled != goal)
            StartFind(ref first, ref second, goal);

        return (_first.Filled == goal) ? new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.One, OtherBucket = _second.Filled } : new TwoBucketResult { Moves = _moves, GoalBucket = Bucket.Two, OtherBucket = _first.Filled };


    }
}
