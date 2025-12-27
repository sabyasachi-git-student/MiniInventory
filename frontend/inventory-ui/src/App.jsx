import { useQuery, useMutation } from "@apollo/client/react";
import { GET_ITEMS, ADD_ITEM, UPDATE_QUANTITY, DELETE_ITEM } from "./graphql";
import { useState } from "react";

export default function App() {
  const { data, loading, error, refetch } = useQuery(GET_ITEMS);

  const [addItem] = useMutation(ADD_ITEM, { onCompleted: () => refetch() });
  const [updateQuantity] = useMutation(UPDATE_QUANTITY, {
    onCompleted: () => refetch(),
  });
  const [deleteItem] = useMutation(DELETE_ITEM, {
    onCompleted: () => refetch(),
  });

  const [form, setForm] = useState({ name: "", type: "", quantity: "" });

  if (loading) return <p>Loading items...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div style={{ padding: 30 }}>
      <h2>Mini Inventory</h2>

      {/* Add Item */}
      <form
        onSubmit={(e) => {
          e.preventDefault();
          addItem({
            variables: {
              name: form.name,
              type: form.type,
              quantity: parseInt(form.quantity),
            },
          });
          setForm({ name: "", type: "", quantity: "" });
        }}
      >
        <input
          placeholder="Name"
          value={form.name}
          onChange={(e) => setForm({ ...form, name: e.target.value })}
        />

        <input
          placeholder="Type"
          value={form.type}
          onChange={(e) => setForm({ ...form, type: e.target.value })}
        />

        <input
          placeholder="Quantity"
          value={form.quantity}
          onChange={(e) => setForm({ ...form, quantity: e.target.value })}
        />

        <button>Add</button>
      </form>

      {/* Items List */}
      <ul>
        {data.items.map((item) => (
          <li key={item.id}>
            {item.name} | {item.type} | Qty:
            <input
              defaultValue={item.quantity}
              onBlur={(e) =>
                updateQuantity({
                  variables: {
                    id: item.id,
                    quantity: parseInt(e.target.value),
                  },
                })
              }
            />
            <button onClick={() => deleteItem({ variables: { id: item.id } })}>
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
