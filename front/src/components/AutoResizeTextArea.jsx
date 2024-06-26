import { Textarea } from '@chakra-ui/react';
import React from 'react';
import ResizeTextarea from 'react-textarea-autosize';

export const AutoResizeTextarea = React.forwardRef(
    function AutoResizeTextarea(props, ref) {
        return <Textarea as={ResizeTextarea} minH="unset" ref={ref} {...props} />;
    }
);
