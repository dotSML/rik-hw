export const required = (value: string) => {
    return value ? undefined : 'This field is required';
};

export const minLength = (length: number) => (value: string) => {
    return value.length >= length ? undefined : `Must be at least ${length} characters`;
};