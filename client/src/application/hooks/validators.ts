export const required = (value: string) => {
  return value ? undefined : 'Väli on kohustuslik';
};

export const minLength = (length: number) => (value: string) => {
  return value.length >= length
    ? undefined
    : `Peab olema vähemalt ${length} tähemärki pikk`;
};

export const isNumber = (value: string) => {
  return !isNaN(Number(value)) ? undefined : 'Peab olema number';
};

export const dateInFuture = (value: string) => {
  const inputDate = new Date(value);
  const today = new Date();

  const inputDateOnly = inputDate.toISOString().split('T')[0];
  const todayOnly = today.toISOString().split('T')[0];

  return inputDateOnly >= todayOnly
    ? undefined
    : 'Kuupäev peab olema tulevikus';
};

export const validateEstonianIdCode = (idCode: string): string | undefined => {
  const weightsFirstRound = [1, 2, 3, 4, 5, 6, 7, 8, 9, 1];
  const weightsSecondRound = [3, 4, 5, 6, 7, 8, 9, 1, 2, 3];

  const digits = idCode.split('').map(Number);

  let checksum =
    digits
      .slice(0, 10)
      .reduce(
        (sum, digit, index) => sum + digit * weightsFirstRound[index],
        0
      ) % 11;

  if (checksum === 10) {
    checksum =
      digits
        .slice(0, 10)
        .reduce(
          (sum, digit, index) => sum + digit * weightsSecondRound[index],
          0
        ) % 11;
  }

  if (checksum === 10) {
    return 'Vigane isikukood';
  }

  if (checksum !== digits[10]) {
    return 'Vigane isikukood';
  }

  return undefined;
};
