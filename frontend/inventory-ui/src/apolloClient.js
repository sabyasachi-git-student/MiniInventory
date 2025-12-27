import { ApolloClient, InMemoryCache, HttpLink } from "@apollo/client";

export const client = new ApolloClient({
  link: new HttpLink({
    uri: "http://localhost:5284/graphql", // backend GraphQL endpoint
  }),
  cache: new InMemoryCache(),
});
