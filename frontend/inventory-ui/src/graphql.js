import { gql } from "@apollo/client";

export const GET_ITEMS = gql`
  query {
    items {
      id
      name
      type
      quantity
    }
  }
`;

export const ADD_ITEM = gql`
  mutation ($name: String!, $type: String!, $quantity: Int!) {
    addItem(name: $name, type: $type, quantity: $quantity) {
      id
      name
      type
      quantity
    }
  }
`;

export const UPDATE_QUANTITY = gql`
  mutation ($id: Int!, $quantity: Int!) {
    updateQuantity(id: $id, quantity: $quantity) {
      id
      name
      type
      quantity
    }
  }
`;

export const DELETE_ITEM = gql`
  mutation ($id: Int!) {
    deleteItem(id: $id)
  }
`;
