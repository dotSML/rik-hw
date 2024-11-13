import { useEffect, useState } from 'react';

const useForm = (initialValues, validators = {}) => {
    const [values, setValues] = useState(initialValues);
    const [errors, setErrors] = useState({});
    const [isValid, setIsValid] = useState(false);

    useEffect(() => {
            setIsValid(!Object.entries(errors).length);
    }, [errors])

    const handleChange = (e) => {
        const { name, value } = e.target;
        setValues((prevValues) => ({ ...prevValues, [name]: value }));

        if (validators[name]) {
            const error = validators[name](value);
            setErrors((prevErrors) => ({ ...prevErrors, [name]: error }));
        }

    };

    const handleBlur = (e) => {
        const { name, value } = e.target;
        if (validators[name]) {
            const error = validators[name](value);
            setErrors((prevErrors) => ({ ...prevErrors, [name]: error }));
        }
    };

    const handleSubmit = (submitCallback) => () => {
        console.log("SUBMIIO")
        const newErrors = {};

        Object.keys(validators).forEach((field) => {
            const error = validators[field](values[field]);
            if (error) newErrors[field] = error;
        });

        setErrors(newErrors);


        if (Object.keys(newErrors).length === 0) {
            submitCallback(values);
        }
    };

    return { isValid, values, errors, handleChange, handleBlur, handleSubmit };
};

export default useForm;
