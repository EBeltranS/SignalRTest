import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { Container } from 'react-bootstrap';
import Test from './components/Test';

export default function App() {
    return (
        <Container >
            <Routes>
                <Route path="/Test" element={<Test />} />
            </Routes>
        </Container>

    )
}