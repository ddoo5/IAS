# What is that?
That's console application which can create indexed database with your words.        
It can count all words, but after indexing.        
It can search any word you want to search and very fast(if you have indexed database)           

# How to use?
You download code or release(add link) and launch. Than you enter path to dictionary and choose options. Dictionary must be only in ```.txt``` type and the dictionary should be without special symbols. For example, you can check [```data.txt```](https://github.com/ddoo5/IAS/blob/main/data.txt). In result you will get, if you choose indexing, indexed [```database.db```](https://github.com/ddoo5/IAS/blob/main/test.db)

# Table of capacity

```
BenchmarkDotNet=v0.13.2, OS=macOS 13.0.1 (22A400) [Darwin 22.1.0]
Intel Core i5-1038NG7 CPU 2.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100

IterationCount=20  WarmupCount=5



|               Method|         Job|               Toolchain|  LaunchCount|    Query|                 Mean|              Error|              StdDev|               Median|                  Min|                  Max|  Ratio|  MannWhitney(10%)|     Gen0|  Allocated|  Alloc Ratio
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|        a|  1,693,028,648.18 ns|  16,261,101.773 ns|   35,003,737.055 ns|  1,678,734,876.50 ns|  1,647,195,543.00 ns|  1,809,081,606.00 ns|  1.000|              Base|        -|      864 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|        a|         22,352.27 ns|         307.787 ns|          688.411 ns|         22,145.15 ns|         21,504.31 ns|         23,806.16 ns|  0.000|            Faster|  12.6343|    39800 B|        46.06
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|        a|  1,807,617,431.90 ns|  20,984,889.183 ns|   24,166,229.589 ns|  1,807,592,269.50 ns|  1,736,114,798.00 ns|  1,838,137,639.00 ns|  1.000|              Base|        -|     1824 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|        a|         23,544.46 ns|         608.741 ns|          701.027 ns|         23,359.93 ns|         22,571.12 ns|         24,927.04 ns|  0.000|            Faster|  12.6343|    39800 B|        21.82
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|  country|  2,368,582,583.88 ns|  31,848,676.678 ns|   70,574,467.618 ns|  2,342,484,070.00 ns|  2,278,042,381.00 ns|  2,535,644,685.00 ns|  1.000|              Base|        -|      200 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|  country|          7,871.52 ns|         149.661 ns|          322.161 ns|          7,847.46 ns|          7,438.92 ns|          8,483.64 ns|  0.000|            Faster|   4.3030|    13584 B|        67.92
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|  country|  2,314,012,988.79 ns|  20,707,898.690 ns|   23,016,774.526 ns|  2,310,177,632.00 ns|  2,274,192,097.00 ns|  2,359,389,921.00 ns|  1.000|              Base|        -|     1784 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|  country|          8,130.80 ns|         144.305 ns|          166.182 ns|          8,114.96 ns|          7,853.83 ns|          8,396.70 ns|  0.000|            Faster|   4.3030|    13584 B|         7.61
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|    param|  2,273,363,811.03 ns|  13,768,419.208 ns|   30,795,042.541 ns|  2,272,816,411.00 ns|  2,218,811,620.00 ns|  2,330,453,028.00 ns|  1.000|              Base|        -|      864 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|    param|             55.87 ns|           0.618 ns|            1.356 ns|             55.79 ns|             53.41 ns|             58.77 ns|  0.000|            Faster|   0.0101|       32 B|         0.04
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|    param|  2,291,754,899.00 ns|  20,609,921.792 ns|   23,734,416.584 ns|  2,288,367,868.00 ns|  2,247,463,361.00 ns|  2,325,127,460.00 ns|  1.000|              Base|        -|     1776 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|    param|             62.98 ns|           1.625 ns|            1.871 ns|             63.01 ns|             60.03 ns|             67.64 ns|  0.000|            Faster|   0.0101|       32 B|         0.02
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|    query|  2,264,843,585.62 ns|  12,410,732.505 ns|   27,758,381.677 ns|  2,264,016,439.00 ns|  2,199,734,697.00 ns|  2,328,461,751.00 ns|  1.000|              Base|        -|     1536 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|    query|             96.00 ns|           1.422 ns|            3.180 ns|             96.15 ns|             90.05 ns|            102.23 ns|  0.000|            Faster|   0.0280|       88 B|         0.06
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|    query|  2,263,909,622.94 ns|  47,616,240.449 ns|   50,948,843.806 ns|  2,252,656,325.00 ns|  2,195,344,184.00 ns|  2,414,045,791.00 ns|  1.000|              Base|        -|     1776 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|    query|             90.79 ns|           0.348 ns|            0.372 ns|             90.84 ns|             90.26 ns|             91.33 ns|  0.000|            Faster|   0.0280|       88 B|         0.05
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|     some|  2,395,158,197.32 ns|  51,487,519.450 ns|  111,929,629.947 ns|  2,318,223,689.00 ns|  2,299,970,700.00 ns|  2,567,711,534.00 ns|  1.000|              Base|        -|      864 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|     some|         14,003.84 ns|          33.080 ns|           68.316 ns|         13,986.99 ns|         13,902.62 ns|         14,208.55 ns|  0.000|            Faster|   8.2550|    26120 B|        30.23
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|     some|  2,318,480,134.45 ns|   2,523,470.554 ns|    2,906,032.443 ns|  2,318,415,576.00 ns|  2,313,306,433.00 ns|  2,325,238,590.00 ns|  1.000|              Base|        -|     1776 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|     some|         14,393.15 ns|          67.459 ns|           74.981 ns|         14,373.85 ns|         14,300.98 ns|         14,538.80 ns|  0.000|            Faster|   8.2550|    26120 B|        14.71
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|     test|  2,319,441,103.02 ns|   4,474,902.500 ns|    9,536,382.070 ns|  2,317,620,688.00 ns|  2,306,740,713.00 ns|  2,355,237,636.00 ns|  1.000|              Base|        -|      864 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|     test|          1,511.67 ns|           3.620 ns|            7.946 ns|          1,511.66 ns|          1,494.46 ns|          1,532.47 ns|  0.000|            Faster|   0.8659|     2720 B|         3.15
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|     test|  2,326,117,753.32 ns|   4,808,540.151 ns|    5,344,679.637 ns|  2,325,073,240.00 ns|  2,316,613,800.00 ns|  2,335,617,620.00 ns|  1.000|              Base|        -|     1776 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|     test|          1,557.33 ns|           6.990 ns|            7.479 ns|          1,555.46 ns|          1,544.75 ns|          1,574.90 ns|  0.000|            Faster|   0.8659|     2720 B|         1.53
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|       to|  2,146,497,381.85 ns|   4,427,992.643 ns|    9,436,413.342 ns|  2,144,653,574.00 ns|  2,133,467,135.00 ns|  2,172,859,694.00 ns|  1.000|              Base|        -|      864 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|       to|         21,436.77 ns|          35.903 ns|           76.512 ns|         21,445.76 ns|         21,281.16 ns|         21,658.61 ns|  0.000|            Faster|  12.6343|    39848 B|        46.12
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|       to|  2,177,501,928.75 ns|   9,194,376.164 ns|    9,030,106.791 ns|  2,177,621,282.50 ns|  2,166,958,133.00 ns|  2,199,708,650.00 ns|  1.000|              Base|        -|     1776 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|       to|         23,859.84 ns|         969.815 ns|        1,116.841 ns|         23,576.54 ns|         22,323.64 ns|         26,768.07 ns|  0.000|            Faster|  12.6343|    39848 B|        22.44
|         SimpleSearch|  Job-XHUFBW|                 Default|            3|     word|  2,276,971,240.57 ns|  13,816,722.118 ns|   30,903,078.921 ns|  2,270,559,173.00 ns|  2,236,500,573.00 ns|  2,380,232,225.00 ns|  1.000|              Base|        -|     1400 B|         1.00
|  FullTextIndexSearch|  Job-XHUFBW|                 Default|            3|     word|          2,022.59 ns|          22.292 ns|           49.860 ns|          2,024.01 ns|          1,942.44 ns|          2,120.98 ns|  0.000|            Faster|   1.0872|     3416 B|         2.44
|         SimpleSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|     word|  2,248,933,230.24 ns|   2,118,985.879 ns|    2,176,042.489 ns|  2,248,748,756.00 ns|  2,246,193,965.00 ns|  2,254,977,881.00 ns|  1.000|              Base|        -|     1776 B|         1.00
|  FullTextIndexSearch|  Job-KYOOPO|  InProcessEmitToolchain|      Default|     word|          2,098.62 ns|           7.364 ns|            8.185 ns|          2,098.71 ns|          2,081.80 ns|          2,114.40 ns|  0.000|            Faster|   1.0872|     3416 B|         1.92


