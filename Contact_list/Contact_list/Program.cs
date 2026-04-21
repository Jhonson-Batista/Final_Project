using Contact_list;

List<Contacto> contactos = new List<Contacto>();
bool running = true;
int choosenOption = 0;

while (running)
{
    Console.WriteLine("\n=== Agenda de Contactos ===");
    Console.WriteLine("1. Agregar contacto");
    Console.WriteLine("2. Listar contactos");
    Console.WriteLine("3. Buscar contacto");
    Console.WriteLine("4. Eliminar contacto");
    Console.WriteLine("5. Salir");
    Console.WriteLine("---------------------------");

    try
    {
        choosenOption = Convert.ToInt32(Console.ReadLine());

        switch (choosenOption)
        {
            case 1:
                {
                    Console.WriteLine("Escribe el nombre:");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Escribe el teléfono:");
                    string telefono = Console.ReadLine();

                    Console.WriteLine("Escribe el email:");
                    string email = Console.ReadLine();

                    int id = contactos.Count + 1;
                    contactos.Add(new Contacto(id, nombre, telefono, email));

                    using (var db = new AgendaContext())
                    {
                        db.Contactos.Add(new Contacto
                        {
                            Nombre = nombre,
                            Telefono = telefono,
                            Email = email
                        });

                        db.SaveChanges();

                        Console.WriteLine("Contacto agregado correctamente.");
                    }
                }
                break;

            case 2:
                {
                    if (contactos.Count == 0)
                    {
                        Console.WriteLine("No hay contactos registrados.");
                        break;
                    }

                    Console.WriteLine("\n--- Lista de Contactos ---");
                    foreach (var contacto in contactos)
                    {
                        Console.WriteLine(contacto.ToString());
                    }
                }
                break;

            case 3:
                {
                    Console.WriteLine("Escribe el nombre a buscar:");
                    string busqueda = Console.ReadLine();

                    bool encontrado = false;

                    for (int i = 0; i < contactos.Count; i++)
                    {
                        if (contactos[i].Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(contactos[i].ToString());
                            encontrado = true;
                        }
                    }

                    if (!encontrado)
                        Console.WriteLine("No se encontró ningún contacto con ese nombre.");
                }
                break;

            case 4:
                using (var db = new AgendaContext())
                {
                    Console.WriteLine("Escribe el ID del contacto a eliminar:");
                    int idEliminar = Convert.ToInt32(Console.ReadLine());

                    var contacto = db.Contactos.FirstOrDefault(c => c.Id == idEliminar);

                    if (contacto != null)
                    {
                        db.Contactos.Remove(contacto);
                        db.SaveChanges();

                        Console.WriteLine("Contacto eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un contacto con ese ID.");
                    }
                }
                break;

            case 5:
                {
                    running = false;
                }
                break;

            default:
                Console.WriteLine("Por favor elige una opción del 1 al 5.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
    }
}

Console.WriteLine("Cerrando la agenda...");
