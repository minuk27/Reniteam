import tkinter as tk

def generate_multiples_of_3():
    text_box.delete(1.0, tk.END)  

    for i in range(1, 10):
        result = 3 * i
        text_box.insert(tk.END, f"3 x {i} = {result}\n")

root = tk.Tk()
root.title("첫번째 버튼")
generate_button = tk.Button(root, text="구구단생성", command=generate_multiples_of_3)
generate_button.pack()
delete_button = tk.Button(root, text="구구단삭제", command=lambda: text_box.delete(1.0, tk.END))
delete_button.pack()
text_box = tk.Text(root)
text_box.pack()
root.mainloop()

