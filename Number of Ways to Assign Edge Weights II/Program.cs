namespace Number_of_Ways_to_Assign_Edge_Weights_II
{
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics.X86;

    public unsafe class Solution
    {
        const int MAX_LEN = 100_001;
        const int LOG2_MAX_LEN = 16;
        private static readonly int* adjBuffer = (int*)NativeMemory.AlignedAlloc(MAX_LEN * 3 * sizeof(int), sizeof(int));
        private static readonly int* ancestorsBuffer = (int*)NativeMemory.AlignedAlloc(MAX_LEN * (LOG2_MAX_LEN + 1) * sizeof(int), sizeof(int));
        private static readonly int* depthsBuffer = (int*)NativeMemory.AlignedAlloc(MAX_LEN * sizeof(int), sizeof(int));

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static int modPow2(long exponent)
            {
                const long MOD = 1_000_000_007;
                const long MAX_DOUBLE_POW2 = (long)(8.98846567431158E+307 % MOD);

                if (exponent < 1024)
                    return (int)(BitConverter.Int64BitsToDouble(exponent + 1023L << 52) % MOD);

                var (res, n) = (MAX_DOUBLE_POW2, 2L);
                for (exponent -= 1023; exponent > 0; exponent >>= 1)
                {
                    if ((exponent & 1) == 1)
                        res = res * n % MOD;
                    n = n * n % MOD;
                }
                return (int)res;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static int findLCA(int* ancestors, int* depths, int u, int v, int stride)
            {
                var (dU, dV) = (depths[u], depths[v]);
                if (dU < dV)
                    (u, dU, v, dV) = (v, dV, u, dU);

                for (var bits = (uint)(dU - dV); bits != 0; bits = Bmi1.ResetLowestSetBit(bits))
                    u = ancestors[stride * (int)Bmi1.TrailingZeroCount(bits) + u];

                if (u == v)
                    return u;

                var a = ancestors + stride * BitOperations.Log2((uint)dV);
                for (; a >= ancestors; a -= stride)
                {
                    if (a[u] != a[v])
                        (u, v) = (a[u], a[v]);
                }
                return ancestors[u];
            }

            static int dfs(int** adj, int* depths, int* ancestors, int prev, int node, int depth)
            {
                depths[node] = depth;
                ancestors[node] = prev;
                var neighbors = adj[node];
                var max = 0;
                for (int i = 1, nextDepth = depth + 1; i <= *neighbors; ++i)
                {
                    var neighbor = neighbors[i];
                    if (neighbor != prev)
                        max = Math.Max(max, dfs(adj, depths, ancestors, node, neighbor, nextDepth));
                }
                return max + 1;
            }

            var n = edges.Length + 1;
            var counts = stackalloc int[n + 1];
            foreach (var e in edges)
            {
                ref var u = ref e[0];
                var v = Unsafe.Add(ref u, 1);
                ++counts[u]; ++counts[v];
            }

            var adj = stackalloc int*[n + 1];
            for (int i = 1, sum = 1; i <= n; ++i)
            {
                var len = adjBuffer + sum;
                *len = 0;
                adj[i] = len;
                sum += counts[i] + 1;
            }

            foreach (var e in edges)
            {
                ref var u = ref e[0];
                var v = Unsafe.Add(ref u, 1);
                adj[u][++*adj[u]] = v;
                adj[v][++*adj[v]] = u;
            }

            *depthsBuffer = 0;
            var height = dfs(adj, depthsBuffer, ancestorsBuffer, 0, 1, 0);
            var logHeight = BitOperations.Log2((uint)height);
            var prev = ancestorsBuffer;
            *prev = 0;
            for (var exp = 1; exp <= logHeight; ++exp)
            {
                var a = prev + (n + 1);
                *a = a[1] = 0;
                for (var i = 2; i <= n; ++i)
                    a[i] = prev[prev[i]];
                prev = a;
            }

            var res = GC.AllocateUninitializedArray<int>(queries.Length);
            for (var i = 0; i < queries.Length; ++i)
            {
                ref var u = ref queries[i][0];
                var v = Unsafe.Add(ref u, 1);
                var lca = findLCA(ancestorsBuffer, depthsBuffer, u, v, n + 1);
                var lcaDepth = depthsBuffer[lca];
                res[i] = modPow2(depthsBuffer[u] + depthsBuffer[v] - (lcaDepth << 1 | 1));
            }
            return res;
        }
    }
}
