int[] ithbarcodes = { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 0, 5, 5, 5 };
Console.WriteLine("Ввод: " + string.Join(" ", ithbarcodes));
Console.WriteLine("Вывод: " + string.Join(" ", GroupNotTheSameNeighbors(ithbarcodes)));

int[] GroupNotTheSameNeighbors(int[] ithbarcodes)
{ 
    ExclusiveElementGroupsAndCountExclusiveCreate(ithbarcodes, out int[] exclusiveelements, out int[] countexclusiveelements);
    ExclusiveGroupAndCountGroupSort(exclusiveelements, countexclusiveelements);

    List<int> result = new List<int>();
    while(result.Count != ithbarcodes.Length)
    { 
        for (int indexcl = 0; indexcl < exclusiveelements.Length; indexcl++)
        {
            if (countexclusiveelements[indexcl] > 0)
            {
                result.Add(exclusiveelements[indexcl]);
                countexclusiveelements[indexcl]--;
            }
        }
    }
    return result.ToArray();
}

void ExclusiveElementGroupsAndCountExclusiveCreate(in int[] ithbarcodes,out int[] exclusiveelements, out int[] countexclusiveelements)
{
    exclusiveelements = ithbarcodes.Distinct().ToArray();
    countexclusiveelements = new int[exclusiveelements.Length];
    for (int indexexclusive = 0; indexexclusive < exclusiveelements.Length; indexexclusive++)
    {
        countexclusiveelements[indexexclusive] = 0;
        for (int index = 0; index < ithbarcodes.Length; index++)
        {
            if (ithbarcodes[index] == exclusiveelements[indexexclusive])
            {
                countexclusiveelements[indexexclusive]++;
            }
        }
    }
}

void ExclusiveGroupAndCountGroupSort(int[] exclusiveelements, int[] countexclusiveelements)
{
    for (int ind = 0; ind < exclusiveelements.Length; ind++)
    {
        int indexmax = ind;
        for (int i = ind; i < exclusiveelements.Length; i++)
        {
            if (countexclusiveelements[i] > countexclusiveelements[indexmax])
            {
                indexmax = i;
            }
        }
        Swap<int>(ref exclusiveelements[ind], ref exclusiveelements[indexmax]);
        Swap<int>(ref countexclusiveelements[ind], ref countexclusiveelements[indexmax]);
    }
}

void Swap<T>(ref T x, ref T y)
{ 
    T temp = x; x = y; y = temp;
}
