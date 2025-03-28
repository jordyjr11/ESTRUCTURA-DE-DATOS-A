public class Nodo {  
    public string Valor;  
    public Nodo izquierdo, derecho;  

    public Nodo(string valor) {  
        Valor = valor;  
        izquierdo = derecho = null;  
    }  
}  

public class Arbol {  
    public Nodo raiz;  

    public void Insertar(string value) {  
        raiz = InsertarRecursivo(raiz, value);  
    }  

    private Nodo InsertarRecursivo(Nodo raiz, string value) {  
        if (raiz == null) {  
            raiz = new Nodo(value);  
            return raiz;  
        }  

        if (string.Compare(value, raiz.Valor) < 0) {  
            raiz.izquierdo = InsertarRecursivo(raiz.izquierdo, value);  
        } else {  
            raiz.derecho = InsertarRecursivo(raiz.derecho, value);  
        }  

        return raiz;  
    }  

    public void ImprimirPreorder() {  
        PreOrder(raiz);  
    }  

    private void PreOrder(Nodo nodo) {  
        if (nodo != null) {  
            System.Console.WriteLine(nodo.Valor);  
            PreOrder(nodo.izquierdo);  
            PreOrder(nodo.derecho);  
        }  
    }  

    public void InOrder() {  
        InOrder(raiz);  
    }  

    private void InOrder(Nodo nodo) {  
        if (nodo != null) {  
            InOrder(nodo.izquierdo);  
            System.Console.WriteLine(nodo.Valor);  
            InOrder(nodo.derecho);  
        }  
    }  

    public void PosOrder() {  
        PosOrder(raiz);  
    }  

    private void PosOrder(Nodo nodo) {  
        if (nodo != null) {  
            PosOrder(nodo.izquierdo);  
            PosOrder(nodo.derecho);  
            System.Console.WriteLine(nodo.Valor);  
        }  
    }  

    public void PrintTree(Nodo nodo, string ident = " ", bool last = true) {  
        if (nodo != null) {  
            System.Console.Write(ident);  
            if (last) {  
                System.Console.Write("└── ");  
                ident += "    ";  
            } else {  
                System.Console.Write("|--- ");  
                ident += "|   ";  
            }  
            System.Console.WriteLine(nodo.Valor);  
            PrintTree(nodo.izquierdo, ident, false);  
            PrintTree(nodo.derecho, ident, true);  
        }  
    }  

    public void PrintSearchPath(string value) {  
        Nodo current = raiz;  

        while (current != null) {  
            System.Console.WriteLine(current.Valor + " -> ");  
            if (string.Compare(value, current.Valor) < 0) {  
                current = current.izquierdo;  
            } else if (string.Compare(value, current.Valor) > 0) {  
                current = current.derecho;  
            } else {  
                break;  
            }  
        }  

        if (current == null) System.Console.WriteLine("No encontrado");  
        else System.Console.WriteLine("Encontrado: " + current.Valor);  
    }  

    // Método para contar nodos en el árbol  
    public int ContarNodos() {  
        return ContarNodosRecursivo(raiz);  
    }  

    private int ContarNodosRecursivo(Nodo nodo) {  
        if (nodo == null) {  
            return 0;  
        }  
        return 1 + ContarNodosRecursivo(nodo.izquierdo) + ContarNodosRecursivo(nodo.derecho);  
    }  

    // Método para obtener el nivel máximo del árbol  
    public int GetNivelMaximo() {  
        return GetNivelMaximoRecursivo(raiz);  
    }  

    private int GetNivelMaximoRecursivo(Nodo nodo) {  
        if (nodo == null) {  
            return 0;  
        }  
        int nivelIzquierdo = GetNivelMaximoRecursivo(nodo.izquierdo);  
        int nivelDerecho = GetNivelMaximoRecursivo(nodo.derecho);  
        return 1 + (nivelIzquierdo > nivelDerecho ? nivelIzquierdo : nivelDerecho);  
    }  

    // Método para contar nodos hoja  
    public int GetNoHojas() {  
        return GetNoHojasRecursivo(raiz);  
    }  

    private int GetNoHojasRecursivo(Nodo nodo) {  
        if (nodo == null) {  
            return 0;  
        }  
        if (nodo.izquierdo == null && nodo.derecho == null) {  
            return 1; // Es un nodo hoja  
        }  
        return GetNoHojasRecursivo(nodo.izquierdo) + GetNoHojasRecursivo(nodo.derecho);  
    }  
    
    // Método para eliminar un nodo  
    public Nodo Eliminar(Nodo raiz, string value) {  
        if (raiz == null) return raiz;  

        if (string.Compare(value, raiz.Valor) < 0) {  
            raiz.izquierdo = Eliminar(raiz.izquierdo, value);  
        } else if (string.Compare(value, raiz.Valor) > 0) {  
            raiz.derecho = Eliminar(raiz.derecho, value);  
        } else {  
            // Nodo encontrado  
            if (raiz.izquierdo == null) return raiz.derecho;  
            else if (raiz.derecho == null) return raiz.izquierdo;  

            // Nodo con dos hijos: obtener el sucesor (el más pequeño en el subárbol derecho)  
            raiz.Valor = ObtenerMinimo(raiz.derecho).Valor;  
            raiz.derecho = Eliminar(raiz.derecho, raiz.Valor);  
        }  
        return raiz;  
    }  

    private Nodo ObtenerMinimo(Nodo nodo) {  
        while (nodo.izquierdo != null) {  
            nodo = nodo.izquierdo;  
        }  
        return nodo;  
    }  
}  