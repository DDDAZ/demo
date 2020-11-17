function isCuteNumberGreaterThan10(arr: number[]) {
    var evenNumbers = findAllEvenNumbers(arr);
    var largest = findTheMax(evenNumbers);
    var result = isGreaterThan10(largest);
    return result;
}

function findAllEvenNumbers(arr: number[]): number[] {
    return arr.filter(value => value % 2 == 0);
}

function findTheMax(arr: number[]): number {
    return Math.max(...arr);
}

function isGreaterThan10(value: number) {
    return value > 10;
}

console.log(isCuteNumberGreaterThan10([1, 4, 5, 7, 8, 90, 0,]))




