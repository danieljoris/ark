from datetime import datetime

from beanie import Link
from domain.entities.animal import Animal
from domain.entities.core.entity import Entity
from domain.entities.veterinary_clinic import VeterinaryClinic
from domain.value_objects.payment_information import PaymentInformation


class Castration(Entity):
    animal: Link[Animal]
    veterinary_clinic: Link[VeterinaryClinic]
    castration_date: datetime
    forwarded_by: str
    payment_information: list[PaymentInformation]

    class Collection:
        name = "castrations"
