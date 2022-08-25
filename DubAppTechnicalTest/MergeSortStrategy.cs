namespace DubAppTechnicalTest;

public class MergeSortStrategy : ISortingStrategy
{
    public int[] Sort(int[] arr)
    {
        return MergeSort(arr, 0, arr.Length - 1);
    }

    #region Private

    private static int[] MergeSort(int[] array, int left, int right)
    {
        //Recursive algorithm stopping condition
        if (left >= right) 
            return array;

        // The exact middle point of our array 
        var middle = left + (right - left) / 2;

        //Recursively sort the left, respectively right part
        MergeSort(array, left, middle);
        MergeSort(array, middle + 1, right);

        //Merge our two sorted arrays
        MergeArray(array, left, middle, right);

        return array;
    }

    //This method will be responsible for combining our two sorted arrays into one array
    private static void MergeArray(int[] array, int left, int middle, int right)
    {
        //Create two temporary arrays for the left and right arrays
        var leftArrayLength = middle - left + 1;
        var rightArrayLength = right - middle;
        var leftTempArray = new int[leftArrayLength];
        var rightTempArray = new int[rightArrayLength];

        //Copy the values into the temporary arrays
        int i, j;
        for (i = 0; i < leftArrayLength; ++i)
            leftTempArray[i] = array[left + i];

        for (j = 0; j < rightArrayLength; ++j)
            rightTempArray[j] = array[middle + 1 + j];

        i = 0;
        j = 0;
        var k = left;
        //while arrays still have elements
        while (i < leftArrayLength && j < rightArrayLength)
            //If item on left array is less than item on right array, add that item to the result array 
            // else the item in the right array wll be added to the results array
            if (leftTempArray[i] <= rightTempArray[j])
                array[k++] = leftTempArray[i++];
            else
                array[k++] = rightTempArray[j++];
        //if only the left array still has elements, add all its items to the results array
        while (i < leftArrayLength) array[k++] = leftTempArray[i++];
        //if only the right array still has elements, add all its items to the results array
        while (j < rightArrayLength) array[k++] = rightTempArray[j++];
    }

    #endregion
}