import { useEffect, useState } from 'react';

const useForm = (initialValues, validators = {}) => {
    const [values, setValues] = useState(initialValues);
    const [errors, setErrors] = useState({});
    const [isTouched, setIsTouched] = useState(false);
    const [isValid, setIsValid] = useState<boolean>(false);

    useEffect(() => {
        if (isTouched) {
            const noErrors = Object.values(errors).every((error) => error === undefined || error === null);
            setIsValid(noErrors);
        }
    }, [errors, isTouched]);

    const handleChange = (e) => {
        const { name, value } = e.target;

        if (!isTouched) {
            setIsTouched(true);
        }

        setValues((prevValues) => ({ ...prevValues, [name]: value }));

        if (validators[name]) {
            const error = validators[name](value);
            console.log('set validators', error);
            setErrors((prevErrors) => ({ ...prevErrors, [name]: error }));
        }
    };

    const handleBlur = (e) => {
        const { name, value } = e.target;

        if (!isTouched) {
            setIsTouched(true);
        }

        if (validators[name]) {
            const error = validators[name](value);
            setErrors((prevErrors) => ({ ...prevErrors, [name]: error }));
        }
    };

    const handleSubmit = (submitCallback) => () => {
        console.log("SUBMIT");
        const newErrors = {};

        Object.keys(validators).forEach((field) => {
            const error = validators[field](values[field]);
            if (error) newErrors[field] = error;
        });

        setErrors(newErrors);

        if (Object.keys(newErrors).length === 0) {
            submitCallback(values);
            setValues(initialValues);
            setIsTouched(false); 
        }
    };

    return { isValid, values, errors, handleChange, handleBlur, handleSubmit };
};

export default useForm;
