from domain.entities.core.entity import Entity
from domain.value_objects.address import Address
from domain.value_objects.phone import Phone


class VeterinaryClinic(Entity):
    name: str
    address: Address
    phones: list[Phone]

    class Collection:
        name = "veterinary_clinics"
