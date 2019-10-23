import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import AutoComplete from './components/autocomplete/autocomplete';

export default () => (
  <Layout>
    <Route exact path='/' component={AutoComplete} />
  </Layout>
);
